﻿//$("#mk-header-login-button").mouseover(function () {
//    $(this).addClass('active');
//    $('#mk-header-subscribe').hide(); 
//    $('#mk-nav-search-wrapper').hide();
//    $('.mk-login-register').show();
//    $('.mk-shopping-cart-box').hide();
//});

//$("#mk-header-subscribe-button").mouseover(function () {
//    $(this).addClass('active');
//    $('.mk-login-register').hide(); 
//    $('#mk-nav-search-wrapper').hide();
//    $('#mk-header-subscribe').show(); 
//    $('.mk-shopping-cart-box').hide();
//});

$(".mk-search-trigger").mouseover(function () {
    $(this).addClass('active');
    $('.mk-login-register').hide();
    $('#mk-header-subscribe').hide();
    $('#mk-nav-search-wrapper').show();
    $('.mk-shopping-cart-box').hide();
});

$(".shoping-cart-link").mouseover(function () {
    $(this).addClass('active');
    $('.mk-login-register').hide();
    $('#mk-header-subscribe').hide();
    $('#mk-nav-search-wrapper').hide();
    $('.mk-shopping-cart-box').show();
});

$("#home-bg").mouseover(function () { 
    $('.mk-login-register').hide();
    $('#mk-header-subscribe').hide();
    $('#mk-nav-search-wrapper').hide();
    $('.mk-shopping-cart-box').hide();
});

