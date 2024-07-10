/* -------------
 * Load More
 * -------------*/


$(document).ready(function () {
  const loadButton = $('#loadMoreBtn');

  var loading = false;
  var page = loadButton.data('page') + 1;
  var group = loadButton.data('group');
  var resultsOnPage = loadButton.data('results-on-page');

  loadButton.click(function () {

    if (loading === true)
      return;

    loading = true;

    loadButton.prop('disabled', loading);

    $.ajax({
      type: 'GET',
      url: '/api/feature/media/ajax-files?group=' + group + '&page=' + page + '&resultsOnPage=' + resultsOnPage,
      contentType: 'application/json; charset=utf-8',
      cache: false,
      success: function (response) {
        $('#pdf-list').last().append(response.data);
        loading = false;
        page++;
        loadButton.prop('disabled', loading);

        if (response.exhausted)
          loadButton.remove();
      },
      error: function (error) {
        loading = false;
        loadButton.prop('disabled', loading);
      }
    });
  });
});