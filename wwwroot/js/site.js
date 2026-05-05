// FastFood Ecommerce - Global Scripts
$(document).ready(function () {
    // 1. Scroll to Top Logic
    $(window).scroll(function () {
        if ($(this).scrollTop() > 300) {
            $('#scrollToTopBtn').fadeIn();
        } else {
            $('#scrollToTopBtn').fadeOut();
        }
    });

    $('#scrollToTopBtn').hover(function () {
        $(this).css('transform', 'translateY(-5px)');
    }, function () {
        $(this).css('transform', 'translateY(0)');
    });

    $('#scrollToTopBtn').click(function () {
        $('html, body').animate({ scrollTop: 0 }, 500);
        return false;
    });

    // 2. Add subtle animations to cards on hover
    $('.product-card').hover(function () {
        $(this).addClass('shadow-lg');
    }, function () {
        $(this).removeClass('shadow-lg');
    });
});
