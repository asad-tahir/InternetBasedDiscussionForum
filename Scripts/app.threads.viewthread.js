$(document).ready(function () {
    if (sessionStorage.getItem('approve_result') == 'success') {
        $.notify("Favourite Toggled Succefully!", 'success');
        sessionStorage.clear();
    }
    function fillThreadBody() {
        var url = '/Api/Threads/' + $('#thread-container').attr('data-thread-id');
        fetch(url)
            .then(response => response.json())
            .then(data => {
                var thread = data;
                $("#title").text(thread.Title);
                $("#author").text('Author: ' + thread.AuthorName);
                $("#body").text(thread.Body);
                if (thread.IsApproved) {
                    if (thread.IsFavourite) {
                        $('#toggle-fav').text('Remove Favourite');
                    }
                    else {
                        $('#toggle-fav').text('Mark Favourite');
                    }
                    $('#toggle-fav').attr('disabled', false);
                }
                else {
                    $('#toggle-fav').attr('disabled', true);
                }
            });
    }
    fillThreadBody();
});
$('#thread-container').on('click', '#toggle-fav', function () {
    var id = $(this).attr('data-thread-id');
    var url = '/Admin/ThreadAction/' + id;
    fetch(url, { method: "PUT" }).then(function () {
        sessionStorage.setItem('approve_result', 'success');
        window.location.reload();
    });
    
});