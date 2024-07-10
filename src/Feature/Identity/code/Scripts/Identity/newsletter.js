/* -------------
 * Load More
 * -------------*/


$(document).ready(function () {
  //Add timeout
  const newsletterForm = $('#newsletter');
  const url = newsletterForm.attr('action');
  const submitButton = $('#newsletterSubmitButton');
  
  var loading = false;

  newsletterForm.submit(function (e) {
    e.preventDefault();

    if (loading === true)
      return;

    loading = true;

    submitButton.prop('disabled', loading);

    var email = $("input[name='newsletterEmail']").val();
    var consent = $("input[name='newsletterConsent']").val();

    $.ajax({
      type: 'POST',
      url: url,
      data: { email, consent },
      success: function (response) {
        $(".newsletter-error").hide(1000, "linear");
        $(".newsletter-success").show(1000, "linear", function () {
          loading = false;
          submitButton.prop('disabled', loading);
        });
        

      },
      error: function (error) {
        $(".newsletter-success").hide(1000, "linear");
        $(".newsletter-error").show(1000, "linear", function () {
          loading = false;
          submitButton.prop('disabled', loading);
        });
      }
    });

    return;
  });
});