$(document).ready(function () {
    $.ajax({
        url: '/Api/Users/pendingusers',
        method: 'GET',
        contentType: 'json',
        success: function (result) {
            result.forEach(function (temp) {
                var userRow = $('#user-data-row').clone();
                userRow.removeAttr('style');
                userRow.removeAttr('id');
                var name = userRow.find('#name');
                name.text(temp.Name);
                name.removeAttr('id');
                var email = userRow.find('#email');
                email.text(temp.Email);
                email.removeAttr('id');
                var actions = userRow.find('#actions');
                actions.removeAttr('id');
                $('tbody').append(userRow);
            });
        }
    });
});