$("a").on('click',function() {
    var div = $(this).attr('href');
    
    $(this).addClass('active').siblings('a').removeClass('active');
    
    $(div).addClass('show').siblings('.content').removeClass('show');
});