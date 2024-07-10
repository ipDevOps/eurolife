const loadNextStepURL = '/api/feature/eurolifecalculatortool/load-next-step';
const getProductsURL = '/api/feature/eurolifecalculatortool/get-offer';
const nextButton = $('#go-to-next-step'); 
const calculationButton = $('#get-product'); 
const stepContent = $('#step-content');
const step1 = 'step-1';
const step2 = 'step-2';
const step3 = 'step-3';
const step4 = 'step-4';
const delay = 1000;
var loading = false;
var step_2_valid = false;
const errorMessage = (document.querySelector('.js-error')) ? document.querySelector('.js-error').innerHTML : "Error";
const successDiv = document.getElementById('calculator-success');


var userSelection = [];

  //step1 - select target
$('[name="target"]').change(function (e) { 
  //save selection to an object
  let targetGroup = {
    key: $(this).val(),
    title: $(this).data('title'),
    image: $(this).data('image')
  };
  userSelection = { targetGroup : targetGroup};

  //console.log({ userSelection });

  //update button
  nextButtonActive();
})

function showNextStep(e) { 
  if (loading)
    return false;

  let loadFromBreadCrumb = (e.dataset.loadfrombreadcrumb === 'true');
  //console.log(e);

  if (!loadFromBreadCrumb && !isButtonActive(nextButton))
    return false;

  //console.log('dataset');
  //console.log(e.dataset);
  let nextStep = e.dataset.nextstep;
  let itemId = e.dataset.itemid;

  loading = true;

  nextButton.prop('disabled', loading);

  userSelection.itemId = itemId
  userSelection.step = nextStep

  if (!loadFromBreadCrumb && nextStep == step3) {//we are on step 2
    fillFamilyMembers();      
  }

  //console.log({ userSelection });

  $.ajax({
    type: 'POST',
    url: `${loadNextStepURL}`,
    contentType: 'application/json; charset=utf-8',
    cache: false,
    data: JSON.stringify(userSelection),
    beforeSend: function () {
      document.querySelector('.js-loading').classList.add('active');
    },
    success: function (response) {
      setTimeout(() => {
        stepContent.html(response);
        loading = false;
        document.querySelector('.js-loading').classList.remove('active');
        breadcrumbStepActive(nextStep);
        nextButton.prop('disabled', loading);
        nextButtonInactive();

        if (nextStep === step1) {
          initializeStep1();
        }


        if (nextStep === step2) {
          initializeStep2();
        }

        if (nextStep === step3) {
          hideSuccessMessage();
          initializeStep3();
        }
      }, delay);      
    },
    error: function (error) {
      setTimeout(() => {
        loading = false;
        nextButton.prop('disabled', loading);
        document.querySelector('.js-loading').classList.remove('active');
      }, delay);
    }
  });
}

function getOffer(e) {
  if (loading)
    return false;

  //console.log('getOffer');
  //console.log({ userSelection });

  var selectedAmount = $('ul.range-labels li[class="active selected"]');
  let amount = { key: $(selectedAmount).data('value'), title: $(selectedAmount).text(), guiid: $(selectedAmount).data('guiid') };

  userSelection.amount = amount;

  var roomoffer = $("input[name=room-offer]");
  var checkedRoom = roomoffer.filter(":checked");
  let hospitalization = { key: $(checkedRoom).attr('id'), title: $(checkedRoom).data('title'), guiid: $(checkedRoom).data('guiid') };

  userSelection.hospitalization = hospitalization;  
  userSelection.step = step4;
 
  //console.log({ userSelection });

  loading = true;
  calculationButton.prop('disabled', loading);
  calculationButton.addClass('btn--inactive');

  $.ajax({
    type: 'POST',
    url: `${getProductsURL}`,
    contentType: 'application/json; charset=utf-8',
    cache: false,
    data: JSON.stringify(userSelection),
    beforeSend: function () {
      document.querySelector('.js-loading').classList.add('active');
    },
    success: function (response) {
      setTimeout(() => {
        stepContent.html(response);
        loading = false;
        breadcrumbStepActive(step4);
        initializeStep4();
        enableTabs();
        calculationButton.prop('disabled', loading);
        calculationButton.removeClass('btn--inactive');
        document.querySelector('.js-loading').classList.remove('active');
      }, delay);
    },
    error: function (error) {
      setTimeout(() => {
        console.log(error);
        loading = false;
        calculationButton.prop('disabled', loading);
        calculationButton.removeClass('btn--inactive');
        document.querySelector('.js-loading').classList.remove('active');
      }, delay);
    }
  });
}

function isButtonActive(button){
  if ($(button).hasClass('btn--inactive'))
    return false;
  else
    return true;
}

function nextButtonActive() {
  nextButton.removeClass('btn--inactive');
}

function nextButtonInactive() {
  nextButton.addClass('btn--inactive');

  if (successMessageStatus())
    hideSuccessMessage();
}

function nextButtonStep(nextStep) {
  //console.log('update button data');
  //console.log(nextStep);
  nextButton.attr({ 'data-nextstep': nextStep });
}

function breadcrumbStepActive(step) {
  //console.log(step);
  $(".bread-in-tool ul li span").removeClass("current");
  $('#bread-' + step).addClass('current'); 
}

function validateYear(e) {
  
  var today = new Date();
  var year = today.getFullYear();

  var birthYear = e.value;
  var age = year - birthYear;


  if (e.classList.contains('js-validate-us-father') || e.classList.contains('js-validate-us-mother')) {
    if (age > 24 && age < 63) {
      e.dataset.isvalid = 'true';
      step2Validity();

    }
    else {
      e.dataset.isvalid = 'false';
      step_2_valid = false;
      nextButtonInactive();
    }
  }

  if (e.classList.contains('js-validate-family-father') || e.classList.contains('js-validate-family-mother'))
  {   
    if (age > 24 && age < 63) {
      e.dataset.isvalid = 'true';
      let mother = document.getElementById('target-is-mother');
      if (mother.classList.contains('family-validation') && isOneParentActive() && isOneChildActive()) step2Validity();
      // else step2Validity();
      
    }
    else
    {
      e.dataset.isvalid = 'false';
      step_2_valid = false;
      nextButtonInactive();
    }
  }

  if (e.classList.contains('js-validate-me-me')) {
    if (age > 24 && age < 63) {
      e.dataset.isvalid = 'true';
      step2Validity(); 
    }
    else {
      e.dataset.isvalid = 'false';
      step_2_valid = false;
      nextButtonInactive();
    }
  }

  if (e.classList.contains('js-validate-family-son') || e.classList.contains('js-validate-family-daughter'))
  {
    if (age >= 0 && age < 24) {
      e.dataset.isvalid = 'true';
      if (isOneParentActive() && isOneChildActive()) step2Validity();
    }
    else {
      e.dataset.isvalid = 'false';
      step_2_valid = false;
      nextButtonInactive();
    }
  }

  if (e.classList.contains('js-validate-child-child')) {
    if (age >= 0 && age < 24) {
      e.dataset.isvalid = 'true';
      step2Validity();
    }
    else {
      e.dataset.isvalid = 'false';
      step_2_valid = false;
      nextButtonInactive();
    }
  }

}


function initializeStep1() {
  $('#common-button-wrapper').show();
  nextButtonStep(step2);

  $('[name="target"]').change(function (e) {
    //save selection to an object
    let targetGroup = {
      key: $(this).val(),
      title: $(this).data('title'),
      image: $(this).data('image')
    };
    userSelection = { targetGroup: targetGroup };

    //console.log({ userSelection });

    //update button
    nextButtonActive();
  })
}


function initializeStep2() {

  $('#common-button-wrapper').show();

  nextButtonStep(step3);

  let father = document.getElementById('target-is-father');
  let mother = document.getElementById('target-is-mother');

  const targetsRemove = document.querySelectorAll('.js-remove-parent');
  if (targetsRemove != null) {
    for (const target of targetsRemove) {
      target.addEventListener('click', _ => {
        target.parentElement.parentElement.classList.add('target-group--deactive');
        const year = target.parentElement.parentElement.getElementsByClassName('js-birth-year');
        year[0].setAttribute("disabled", "disabled");
        const choice = target.parentElement.parentElement.getElementsByClassName('js-radio-choice');
        choice[0].setAttribute("disabled", "disabled");

        //transfering primary person
        if (mother.classList.contains('target-group--deactive')) document.getElementById('man-is-primary').click();
        if (father.classList.contains('target-group--deactive')) document.getElementById('woman-is-primary').click();

        if (isOneParentActive() == false) nextButtonInactive();

        var messenegerDiv = document.getElementById('calculator-custom-validation');
        if (messenegerDiv.classList.contains('max-persons')) {

          messenegerDiv.innerHTML = '';
          messenegerDiv.classList.add('hidden');
          messenegerDiv.classList.remove('max-persons');
        }

      });
    }
  }

  const targetsAdd = document.querySelectorAll('.js-add-parent');
  if (targetsAdd != null) {
    for (const target of targetsAdd) {
      target.addEventListener('click', _ => {


        if (allowMorePeople()) {
          //if birthyear is invalid, deactivate next button
          let targetInput = target.parentElement.parentElement.getElementsByClassName('js-birth-year');
          console.log(targetInput[0].dataset.isvalid)
          if (targetInput[0].dataset.isvalid == "false") nextButtonInactive();

          target.parentElement.parentElement.classList.remove('target-group--deactive');
          const year = target.parentElement.parentElement.getElementsByClassName('js-birth-year');
          const choice = target.parentElement.parentElement.getElementsByClassName('js-radio-choice');
          year[0].removeAttribute("disabled");
          choice[0].removeAttribute("disabled");

          if (father.classList.contains('target-group--deactive')) document.getElementById('woman-is-primary').click();
          if (mother.classList.contains('target-group--deactive')) document.getElementById('man-is-primary').click();
        }
        else {
          console.log('no more people allowed max 6')
          var messenegerDiv = document.getElementById('calculator-custom-validation');
          messenegerDiv.innerHTML = 'Ο μέγιστος αριθμός ατόμων που μπορούν να ασφαλιστούν είναι 6.';
          messenegerDiv.classList.add('max-persons');
          messenegerDiv.classList.remove('hidden');
        }

      });
    }
  }

  //add pr remove daughters
  var count;
  let daughterPlaceholder = document.getElementById('daughter-placeholder');
  if (daughterPlaceholder) count = parseInt(daughterPlaceholder.dataset.daughtercounter);


  const daughtersAdd = document.querySelectorAll('.js-add-daughter');
  if (daughtersAdd != null) {

    let newChild =
      `<div class="target-group__birth target-group__added-daughter">
          <input type="text" class="js-birth-year js-validate-family-daughter" onkeyup="validateYear(this,arguments)" maxlength="4" pattern="^(19|20)\d{2}$" data-isvalid="false">
          <label>Έτος γέννησης</label>
          <span class="error">` + errorMessage + `</span>
        </div>`;

    for (const daughter of daughtersAdd) {
      daughter.addEventListener('click', _ => {

        if (allowMorePeople()) {

          nextButtonInactive();
          if (count < 3) {
            count = count + 1;
            daughterPlaceholder.dataset.daughtercounter = count;

            if (count > 1) daughterPlaceholder.insertAdjacentHTML('beforeend', newChild);
          }

        }
        else {
          console.log('no more people allowed max 6')
          var messenegerDiv = document.getElementById('calculator-custom-validation');
          messenegerDiv.innerHTML = 'Ο μέγιστος αριθμός ατόμων που μπορούν να ασφαλιστούν είναι 6.';
          messenegerDiv.classList.add('max-persons');
          messenegerDiv.classList.remove('hidden');
        }



      });
    }
  }

  const daughtersRemove = document.querySelectorAll('.js-remove-daughter');
  if (daughtersRemove != null) {

    for (const daughter of daughtersRemove) {
      daughter.addEventListener('click', _ => {

        if (count > 0) {

          count = count - 1;
          daughterPlaceholder.dataset.daughtercounter = count;

          setTimeout(function () {
            if ((isOneChildActive() == false || isOneParentActive() == false)) {
              nextButtonInactive();
            }

          }, 100);

          const nodesToRemove = document.querySelectorAll('.target-group__added-daughter');
          if (nodesToRemove.length > 0) daughterPlaceholder.removeChild(nodesToRemove[0]);

          var messenegerDiv = document.getElementById('calculator-custom-validation');
          if (messenegerDiv.classList.contains('max-persons')) {

            messenegerDiv.innerHTML = '';
            messenegerDiv.classList.add('hidden');
            messenegerDiv.classList.remove('max-persons');
          }
        }

      });
    }
  }
  //add or remove daughters ends


  //add or remove sons
  var sonscount;
  let sonPlaceholder = document.getElementById('son-placeholder');
  if (sonPlaceholder) sonscount = parseInt(sonPlaceholder.dataset.soncounter);


  const sonsAdd = document.querySelectorAll('.js-add-son');
  if (sonsAdd != null) {

    let newChild =
      `<div class="target-group__birth target-group__added-son">
          <input type="text" class="js-birth-year js-validate-family-son" onkeyup="validateYear(this,arguments)" maxlength="4" pattern="^(19|20)\d{2}$" data-isvalid="false">
          <label>Έτος γέννησης</label>
          <span class="error">` + errorMessage + `</span>
        </div>`;

    for (const son of sonsAdd) {
      son.addEventListener('click', _ => {

        if (allowMorePeople()) {
          nextButtonInactive();
          if (sonscount < 3) {
            sonscount = sonscount + 1;
            sonPlaceholder.dataset.soncounter = sonscount;

            if (sonscount > 1) sonPlaceholder.insertAdjacentHTML('beforeend', newChild);
          }
        }
        else {
          console.log('no more people allowed max 6')
          var messenegerDiv = document.getElementById('calculator-custom-validation');
          messenegerDiv.innerHTML = 'Ο μέγιστος αριθμός ατόμων που μπορούν να ασφαλιστούν είναι 6.';
          messenegerDiv.classList.add('max-persons');
          messenegerDiv.classList.remove('hidden');
        }

      });
    }
  }

  const sonsRemove = document.querySelectorAll('.js-remove-son');
  if (sonsRemove != null) {

    for (const son of sonsRemove) {
      son.addEventListener('click', _ => {
        if (sonscount > 0) {
          sonscount = sonscount - 1;
          sonPlaceholder.dataset.soncounter = sonscount;

          setTimeout(function () {
            if ((isOneChildActive() == false || isOneParentActive() == false)) {
              nextButtonInactive();
            }

          }, 100);

          const nodesToRemove = document.querySelectorAll('.target-group__added-son');

          if (nodesToRemove.length > 0) sonPlaceholder.removeChild(nodesToRemove[0]);

          var messenegerDiv = document.getElementById('calculator-custom-validation');
          if (messenegerDiv.classList.contains('max-persons')) {

            messenegerDiv.innerHTML = '';
            messenegerDiv.classList.add('hidden');
            messenegerDiv.classList.remove('max-persons');
          }

        }

      });
    }
  }
  //add or remove sons ends


  Array.prototype.slice.call(document.querySelectorAll('.js-target'))
    .map(function (container) {
      return {
        input: container.querySelector('.person-number'),
        decrease: container.querySelector('.symbol--minus'),
        increase: container.querySelector('.symbol--plus'),
        yearinput: container.querySelector('.target-group__birth input'),
        get value() { return parseInt(this.input.value); },
        set value(v) { this.input.value = v; }
      }
    })
    .forEach(function (item) {
      item.decrease.addEventListener('click', function () {
        if (item.value > 0) item.value -= 1;
        if (item.value == 0) {
          item.yearinput.setAttribute("disabled", "disabled");
          item.yearinput.value = '';
          this.parentElement.parentElement.classList.add('target-group--deactive');
        }
      });
      item.increase.addEventListener('click', function () {
        if (item.value < 3) item.value += 1;
        if (item.value == 1) {
          item.yearinput.removeAttribute("disabled");
          this.parentElement.parentElement.classList.remove('target-group--deactive');
        }
      });
    });

  const init = () => {
    //INITIAL STATE - ALL CLICKED
    Array.prototype.slice.call(document.querySelectorAll('.js-add-parent, .js-add-son, .js-add-daughter')).map((item) => {
      item.click();
    });

    //SELECT MOTHER AND FOCUS HER
    Array.prototype.slice.call(document.querySelectorAll('.target-group__item')).map((item) => {
      if (item.getAttribute('data-key') == "mother") {
        item.click();
        item.querySelector('.js-add-parent').click();
        item.querySelector('.js-birth-year').focus();
      }
    });
  };

  //ADD CLASS ON BLUR AND VALUE
  const blurAndValue = () => {
    $(document).on("change", ".js-birth-year", (e) => {
      const item = e.target;

      item.addEventListener("blur", () => {
        if (item.value.length > 0)
          item.classList.add("filled");
        else
          item.classList.remove("filled");
      });
    });
  };

  //MORE THAN 2 PERSONS
  if (Array.prototype.slice.call(document.querySelectorAll('.target-group__item').length >= 2))
    setTimeout(() => {
      //init();
      blurAndValue();
    }, 10);
}


function allowMorePeople() {
  var howManyPeople = document.querySelectorAll("[data-isvalid='true']");
  //console.log('TOTAL PEOPLE VALIDATION' + howManyPeople.length);
  if (howManyPeople.length < 6)
    return true;
  else
    return false;

}

function isOneParentActive() {

  let father = document.getElementById('target-is-father');
  let mother = document.getElementById('target-is-mother');

  if (mother.classList.contains('target-group--deactive') && father.classList.contains('target-group--deactive'))
  {
    //console.log('no parent')
    return false;
  }
    
  else
    return true;

}

function isOneChildActive() {

  let son = document.getElementById('target-is-son');
  let daughter = document.getElementById('target-is-daughter');

  if (son.classList.contains('target-group--deactive') && daughter.classList.contains('target-group--deactive')) {
    //console.log('no child')
    return false;
  }

  else
    return true;

}


function step2Validity() {

  $(".target-group.item-targeted").children().each(function (item) {    
    if ($(this).hasClass('target-group--deactive')) {
     // console.log('deactive');     
    } else {
      var invalidElements = $(this).find('[data-isvalid="false"]');    
      if (invalidElements.length > 0) {
        step_2_valid = false;
        return false;
      } else {
        step_2_valid = true; 
      }     
    }
  });

  let sonscount;
  let daughterscount;
  let sonPlaceholder = document.getElementById('son-placeholder');
  let daughterPlaceholder = document.getElementById('daughter-placeholder');
  if (sonPlaceholder && daughterPlaceholder) {
    sonscount = parseInt(sonPlaceholder.dataset.soncounter);
    daughterscount = parseInt(daughterPlaceholder.dataset.daughtercounter);

    let childrenSum = sonscount + daughterscount;
    //console.log("SUM: " + childrenSum);

    if (childrenSum > 4) step_2_valid = false;
  }

  if (step_2_valid) {
    showSuccessMessage();
    nextButtonActive();
  } else
    hideSuccessMessage();
  
   
}

function fillFamilyMembers() {
  let familyMembers = [];
  $(".target-group.item-targeted").children().each(function (item) {
    if (!$(this).hasClass('target-group--deactive')) {
      var image = $(this).find("img");
      var birthDate = $(this).find('.js-birth-year');
      var isPrimaryInsured = false;
      var inputPrimary = $(this).find("input[name=primary-insured]");

      if (inputPrimary.length > 0) {
        var isChecked = inputPrimary.filter(":checked");
        if (isChecked.length > 0) {
          //console.log("is Checked");
          isPrimaryInsured = true;
        }
      }

      var title = $(this).find('[data-title]').first().data('title');

      var childNumberInput = $(this).find('.person-number');

      if (childNumberInput.length > 0) {
        var childVal = $(childNumberInput).val();
        title = `${childVal} ${title}`;
      }

      birthDate.each(function (b) {
        let familyMember = {
          image: image.first().attr("src"),
          birthDate: $(this).val(),
          title: title,
          isPrimaryInsured: isPrimaryInsured
        };
        //console.log(familyMember);
        familyMembers.push(familyMember);
      });     
    }
  });

  userSelection.familyMembers = familyMembers;
}


function initializeStep3() {
  //console.log("step 3");

  //clear common button wrapper
  $('#common-button-wrapper').hide();

  //range
  var sheet = document.createElement('style'),
    $rangeInput = $('.range input'),
    prefs = ['webkit-slider-runnable-track', 'moz-range-track', 'ms-track'];

  document.body.appendChild(sheet);

  var getTrackStyle = function (el) {
    //console.log(el.getAttribute('data-index'))
    var curVal = el.value,
      val = (el.getAttribute('data-index') - 1) * 25,
      style = '';

    // Set active label
    $('.range-labels li').removeClass('active selected');
    //console.log(curVal)
    var curLabel = $('.range-labels').find('[data-value="' + curVal + '"]');

    curLabel.addClass('active selected');
    curLabel.prevAll().addClass('selected');

    // Change background gradient
    for (var i = 0; i < prefs.length; i++) {
      style += '.range {background: linear-gradient(to right, #383B38 0%, #37adbf ' + val + '%, #fff ' + val + '%, #fff 100%)}';
      style += '.range input::-' + prefs[i] + '{background: linear-gradient(to right, #383B38 0%, #383B38 ' + val + '%, #b2b2b2 ' + val + '%, #b2b2b2 100%)}';
    }

    return style;
  }

  $rangeInput.on('input', function () {
    sheet.textContent = getTrackStyle(this);
  });

  //MODAL ENABLE
  document.querySelectorAll(".js-toggle-modal").forEach((item) => {
    item.addEventListener("click", (e) => {
      e.preventDefault();
      toggleExplanationModal();
    });
  });

  // Change input value on label click
  $('.range-labels li').on('click', function () {
    var index = $(this).index();
    // console.log($(this).attr('data-value'))
    $rangeInput.attr('data-index', $(this).attr('data-liindex'));
    $rangeInput.val($(this).attr('data-value')).trigger('input');

    if ($(this).attr('data-value') == "750") {
      document.getElementById("B").click();
      document.getElementById("A").classList.add("disabled");
      document.getElementById("A").disabled = true;
    }
    else {
      document.getElementById("A").disabled = false;
      document.getElementById("A").classList.remove("disabled");
    }
  });

  //MANUALLY CLICK THE FIRST ELEMENT
  setTimeout(() => {
    $('.range-wrapper ul li:nth-child(1)').trigger("click");
  }, 100);
}

function SelectProgram(e) {
  //leave one program selected
  const items = document.querySelectorAll(".pick__item");
  for (let i = 0; i < items.length; i++) {
    const item = items[i];
    item.classList.remove("pick__item--selected");
  }

  e.closest('.pick__item').classList.add('pick__item--selected');

  var selectedDuration = $("#covers_duration").val();
  var selectedCovers = e.closest('.pick__item').querySelectorAll(`[data-${selectedDuration}]`);
  if (selectedCovers.length > 0) {
    var cover = selectedCovers[0];
    var price = $(cover).attr(`data-${selectedDuration}`);   
    recalculateTotalCost(parseFloat(price));
  }
}

function ExpandProgram(e) {
  //expand program
  e.querySelector('.pick__head').classList.toggle('pick-on');
}

function ActivateExtras(e) {
  //activate extras
  const items = document.querySelectorAll(".product-extra-radio");
  const extras = document.getElementsByClassName("pick--extras");
  //console.log(extras)
  if (extras.length > 0) extras[0].classList.toggle('pick--extras__deactive');

  for (let i = 0; i < items.length; i++) {
    const item = items[i];

    if (e.checked == true) {
      item.removeAttribute("disabled");
    }
    else {
      item.setAttribute("disabled", "disabled");
      item.checked = false;
      resetTotalCostToDefault();
    }
  }
}

function initializeStep4() {
  //console.log("step 4");

  $("#covers_duration").change(function () {
    //console.log('covers duration');
    var selected = this.value;
    var bundleDurationTitle = $(this).find(':selected').attr('data-bundlesduration');
    //console.log(selected);
    const items = document.querySelectorAll(`[data-${selected}]`);
    var totalCost = 0;

    if (items.length > 0) {
      $(items).each(function (index, item) {
        //console.log(item);
        var price = $(item).attr(`data-${selected}`);
        //console.log(price);
        $(item).text(numberToGreekFormat(price));       
       
        if (index == 0 || (index > 0 && $(item).parent().parent().hasClass('pick__item--selected')))
          totalCost += parseFloat(price);
      });

       //update label in bundle    
      const bundles = document.querySelectorAll('.cover_duration');

      if (bundles.length > 0) {
        $(bundles).each(function (index, item) {
          //console.log(item);
          //console.log(bundleDurationTitle);
          $(this).text(bundleDurationTitle);
        });
      }

      //console.log('totalCost: ', { totalCost });
      setTotalCost(totalCost);  
    }
  });

  //MODAL ENABLE
  document.querySelectorAll(".js-toggle-modal").forEach((item) => {
    item.addEventListener("click", (e) => {
      e.preventDefault();
      toggleExplanationModal();
    });
  });
}

function getProductPrice() {
  var selected = $("#covers_duration").val();
  var floatPrice = 0;

  const items = document.querySelectorAll(`[data-${selected}]`);
  if (items.length > 0) {
    var product = items[0];
    var price = $(product).attr(`data-${selected}`);
    floatPrice =  parseFloat(price);
  } 
  return floatPrice;
}

function resetTotalCostToDefault() {
  var productCost = getProductPrice();
  setTotalCost(productCost);
}

function recalculateTotalCost(extraCost) {
  var totalCost = getProductPrice();
  totalCost += parseFloat(extraCost);
  setTotalCost(totalCost);
}

function setTotalCost(totalCost) {
  $('#totalCost').text(numberToGreekFormat(totalCost));
}

function numberToGreekFormat(number) {
  const elFormatter = new Intl.NumberFormat("el-GR");
  var round = (Math.round(number * 100) / 100).toFixed(2);
  return elFormatter.format(round).toString() + " €";
}

const showSuccessMessage = () => {
  hideDisclaimer();
  successDiv.classList.remove('hidden');
};

const hideSuccessMessage = () => {
  successDiv.classList.add('hidden');
};

const hideDisclaimer = () => {
  if (document.querySelector('.disclaimer'))
    document.querySelector('.disclaimer').classList.add('hidden');
};

const successMessageStatus = () => {
  return successDiv.classList.contains("hidden");
};

const toggleExplanationModal = () => {
  document.querySelector('.js-tool-modal').classList.toggle("active");
};

const enableTabs = () => {
  document.querySelectorAll(".js-tab").forEach((tab, tab_index) => {
    tab.addEventListener("click", (e) => {
      e.preventDefault();

      document.querySelectorAll(".js-tab").forEach((item, index) => {
        if (index === tab_index)
          item.classList.add("active");
        else
          item.classList.remove("active");
      });

      document.querySelectorAll(".js-tabs .innertab").forEach((t, tindex) => {
        if (tindex === tab_index)
          t.classList.add("active");
        else
          t.classList.remove("active");
      });
    });
  });
};
