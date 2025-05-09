function getBalance() {
    $.ajax({
        url: '/Account/GetBalance',
        method: 'GET',
        success: function (balance) {
            $('#user-balance').text(balance.toFixed(2));
        },
        error: function (error) {
            if (error.status === 401) return;
            console.error('Error during getBalance:', error);
            alert('Error during getBalance:', error);
        }
    });
}

$(function () {
    getBalance();
});