function BlazorScrollToId(id) {
    const element = document.getElementById(id);

    var dummy = $('<div></div>').css({
        position: 'absolute', top: $(element).offset().top - 100
    }).appendTo('body');
    dummy[0].scrollIntoView();
    dummy.remove();
}