function BlazorScrollToId(id) {
    const element = document.getElementById(id);

    var dummy = $('<div></div>').css({
        position: 'absolute', top: $(element).offset().top - 100
    }).appendTo('body');
    dummy[0].scrollIntoView();
    dummy.remove();
}

var swiper = null;

function SetSwiper() {
    swiper = new Swiper(".mySwiper", {
        loop: true,
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
        autoplay: {
            delay: 5000,
        }
    });
}