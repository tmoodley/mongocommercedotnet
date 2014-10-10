$("#mk-header-login-button").click(function () {
    $('#mk-header-subscribe').hide(); 
    $('#mk-nav-search-wrapper').hide();
    $('.mk-login-register').show();
});

$("#mk-header-subscribe-button").click(function () {
    $('.mk-login-register').hide(); 
    $('#mk-nav-search-wrapper').hide();
    $('#mk-header-subscribe').show();
});

$(".mk-search-trigger").click(function () {
    $('.mk-login-register').hide();
    $('#mk-header-subscribe').hide();
    $('#mk-nav-search-wrapper').show();
}); 

