$(document).ready(function () {
    $.ajax({
        url: '/Api/Threads',
        method: 'GET',
        contentType: 'json',
        success: function (result) {
            result.forEach(function (thread) {
                var threadRowCopy = $('#thread-data-row').clone();
                var threadRow = $('#thread-data-row');
                threadRow.removeAttr('style');
                threadRow.removeAttr('id');
                var name = threadRow.find('#author');
                name.text(thread.AuthorName);
                name.removeAttr('id');
                var title = threadRow.find('#title');
                title.text(thread.Title);
                title.attr('href', '/thread/viewthread/' + thread.Id)
                title.removeAttr('id');
                
                var fav = threadRow.find('#fav');
                if (!thread.IsFavourite) {
                    fav.html('');
                }
                fav.removeAttr('id');

                $('tbody').append(threadRow);
                $('#sample-row-table').append(threadRowCopy);
            });
            $('#sample-row-table').remove();
            $('#threads-table').DataTable({
                "order": [[2, "desc"]]
            });
        }
    });
});
