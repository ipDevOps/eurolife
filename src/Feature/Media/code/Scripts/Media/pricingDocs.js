/* -------------
 * Download pricing docs from specific folder
 * -------------*/

$(document).ready(function () {
  $("#datepickerFiles").datepicker({
    dateFormat: 'dd/mm/yy',
    regional:'el',
    todayHighlight: true
  });

  const downloadButton = $('#btnDownloadDoc'); 
  var file = file
  var loading = false; 
;


  downloadButton.click(function () {  
    loading = true;
    downloadButton.prop('disabled', loading);
    $("#lblWarning").css('display', 'none');

    var date = $('#datepickerFiles').val();

    if (date == null || date == "")
       return false; 

    var dates = date.split("/");

    var fileName = 'dat_' + dates[0] + "_" + dates[1] + "_" + dates[2] + ".pdf";  

      $.ajax({
        type: 'POST',
        url: "/api/feature/media/pricing-docs",         
        data: { fileName: fileName},        
        cache: false,
        success: function (response) {            

            let blob = new Blob(['\ufeff' + response], { type: 'application/pdf;charset=utf-8;' });
            let dwldLink = document.createElement("a");
            let url = URL.createObjectURL(blob);
            let isSafariBrowser = navigator.userAgent.indexOf('Safari') !== -1 && navigator.userAgent.indexOf('Chrome') === -1;
            if (isSafariBrowser) {
              dwldLink.setAttribute("target", "_blank");
            }
            dwldLink.setAttribute("href", url);
            dwldLink.setAttribute("download", fileName);
            dwldLink.style.visibility = "hidden";
            document.body.appendChild(dwldLink);
            dwldLink.click();
            document.body.removeChild(dwldLink); 

            loading = false;       
            downloadButton.prop('disabled', loading);      
          },
        error: function (error) {
          console.log(error);
            loading = false;
            downloadButton.prop('disabled', loading);
            $("#lblWarning").css('display', 'block');
          }
    });

  });       

});