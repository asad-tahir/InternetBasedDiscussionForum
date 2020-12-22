$(document).ready(function () {
    if (sessionStorage.getItem('approve_result') == 'success') {
        $.notify("Thread Approved!", 'success');
        sessionStorage.clear();
    }
    $.ajax({
        url: '/Api/Threads/' + $('#thread-container').attr('data-thread-id'),
        method: 'GET',
        contentType: 'json',
        success: function (thread) {
            $("#title").text(thread.Title);
            $("#author").text('Author: ' + thread.AuthorName);
            $("#body").text(thread.Body);

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