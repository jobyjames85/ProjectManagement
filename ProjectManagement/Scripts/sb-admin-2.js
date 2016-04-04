$(function () {
    $('#side-menu').metisMenu();
});

//Loads the correct sidebar on window load,
//collapses the sidebar on window resize.
// Sets the min-height of #page-wrapper to window size
$(function () {
    $(window).bind("load resize", function () {
        topOffset = 50;
        width = (this.window.innerWidth > 0) ? this.window.innerWidth : this.screen.width;
        if (width < 768) {
            $('div.navbar-collapse').addClass('collapse');
            topOffset = 100; // 2-row-menu
        } else {
            $('div.navbar-collapse').removeClass('collapse');
        }

        height = ((this.window.innerHeight > 0) ? this.window.innerHeight : this.screen.height) - 1;
        height = height - topOffset;
        if (height < 1) height = 1;
        if (height > topOffset) {
            $("#page-wrapper").css("min-height", (height) + "px");
        }
    });

    ////$('ul.nav a').click(function () { $('a').css("background-color", "#EEE") })

    ////$('ul.nav a').click(function () { $(this).css("background-color", "yellow") })

    //    $('ul.nav li').focusout(function () {
    //        $(this).css("background-color", "#EEE") });
    //});

    $('ul.nav li').focus(function () {
        $(this).attr('id', 'NavSelected');
        $('#NavSelected').css("background-color", "yellow");
    });

    //$(function () { $('#NavSelected').css("background-color", "yellow") });

    $('ul.nav li').filter(function () {
        var name = $(this).data("module");
        if (!name)
            return;

        if (name == window.currentModulename) {
            $(this).parent().addClass("in").closest("li").addClass("active");
            $(this).parent().addClass("in").closest("li").children("a").addClass("active");
        }
    });
    //var url = window.location;$(element).attr('id', 'newID');
    //var element = $('ul.nav a').filter(function() {
    //    return this.href == url || url.href.indexOf(this.href) == 0;
    //}).addClass('active').parent().parent().addClass('in').parent();
    //if (element.is('li')) {
    //    element.addClass('active');
    //}
});