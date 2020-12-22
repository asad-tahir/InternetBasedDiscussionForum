$(document).ready(function () {
    if (sessionStorage.getItem('approve_result') == 'success') {
        $.notify("Thread Approved!", 'success');
        sessionStorage.clear();
    }
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
                var actions = threadRow.find('#actions');
                if (thread.IsApproved) {
                    actions.html('');
                    actions.text('Approved');
                    actions.removeAttr('id');
                } else {
                    actions.find('.approve').attr('data-id', thread.Id);
                    actions.removeAttr('id');
                }
                var fav = threadRow.find('#fav');
                if (!thread.IsFavourite) {
                    fav.find('.material-icons').css('display','none');
                }
                fav.removeAttr('id');
                
                $('tbody').append(threadRow);
                $('tbody').append(threadRowCopy);
            });
        }
    });
});
$('table').on('click', '.approve', function () {
    var id = $(this).attr('data-id');
    $.ajax({
        url: '/api/threads/' + id,
        method: 'PUT',
        success: function () {
            sessionStorage.setItem('approve_result', 'success');
            window.location.reload();
        }
    });
});