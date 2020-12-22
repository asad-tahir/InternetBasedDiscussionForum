
$(document).ready(function () {
    if (sessionStorage.getItem('approve_result') == 'success') {
        $.notify("Account Approved!", 'success');
        sessionStorage.clear();
    }
    $.ajax({
        url: '/Api/Users',
        method: 'GET',
        contentType: 'json',
        success: function (result) {
            if (result.length === 0) {
                $('#users-table').css('display', 'none');
                $('#nousers').removeAttr('style');
            }
            result.forEach(function (user) {
                var userRowCopy = $('#user-data-row').clone();
                var userRow = $('#user-data-row');
                userRow.removeAttr('style');
                userRow.removeAttr('id');
                var name = userRow.find('#name');
                name.text(user.Name);
                name.removeAttr('id');
                var email = userRow.find('#email');
                email.text(user.Email);
                email.removeAttr('id');
                var actions = userRow.find('#actions');
                actions.find('.approve').attr('data-id', user.Id);
                actions.removeAttr('id');
                $('tbody').append(userRow);
                $('tbody').append(userRowCopy);
            });
        }
    });
});
$('table').on('click','.approve', function () {
    var id = $(this).attr('data-id');
    $.ajax({
        url: '/api/users/' + id,
        method: 'PUT',
        success: function () {
            sessionStorage.setItem('approve_result', 'success');
            window.location.reload();
        }
    });
});