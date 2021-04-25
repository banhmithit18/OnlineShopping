// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

//header
//swiper
var swiper = new Swiper('.swiper-container', {
    spaceBetween: 30,
    centeredSlides: true,
    autoplay: {
        delay: 500000,
        disableOnInteraction: false,
    },
    pagination: {
        el: '.swiper-pagination',
        clickable: true,
    },
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
    },
});

//navigation sticky
window.onscroll = function () { myFunction() };

var header = document.getElementById("header");
var banner = document.getElementById("banner");
var sticky = header.offsetTop;

function myFunction() {
    if (window.pageYOffset > sticky) {
        header.classList.add("sticky");
        banner.style.display = "none";


    } else {
        header.classList.remove("sticky");
        banner.style.display = "block ";
    }
}

// button scroll to top
function scrollToTop() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}

//choose color clothes
$(document).ready(function () {
    $(".color-wrap ul li").each(function (item) {
        var color = $(this).attr("data-color");
        $(this).css("backgroundColor", color);
    })
    $(".color-wrap ul li").each(function (item) {
        $(this).click(function () {
            $(this).parents(".product").find(".color-wrap ul li").removeClass("active")
            $(this).addClass("active");

            var imgsrc = $(this).attr("data-src");
            $(this).parents(".product").find("img").attr("src", imgsrc);
        })
    })
})


