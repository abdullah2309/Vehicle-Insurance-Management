(function ($) {
  "use strict";

  $(".nice-select").niceSelect();

  //Hide Loading Box (Preloader)
  function handlePreloader() {
    if ($(".loading-window-outer").length) {
      $(".loading-window-outer").delay(200).fadeOut(500);
    }
  }

  //Update Header Style and Scroll to Top
  function headerStyle() {
    if ($(".main-header").length) {
      var windowpos = $(window).scrollTop();
      var siteHeader = $(".main-header");
      var scrollLink = $(".scroll-to-top");

      var HeaderHight = $(".main-header").height();
      if (windowpos >= HeaderHight) {
        siteHeader.addClass("fixed-header");
        scrollLink.fadeIn(300);
      } else {
        siteHeader.removeClass("fixed-header");
        scrollLink.fadeOut(300);
      }
    }
  }

  headerStyle();

  //Submenu Dropdown Toggle
  if ($(".main-header li.dropdown ul").length) {
    $(".main-header li.dropdown").append(
      '<div class="dropdown-btn"><span class="fa fa-angle-down"></span></div>'
    );

    //Dropdown Button
    $(".main-header li.dropdown .dropdown-btn").on("click", function () {
      $(this).prev("ul").slideToggle(500);
    });

    //Dropdown Menu / Fullscreen Nav
    $(".fullscreen-menu .navigation li.dropdown > a").on("click", function () {
      $(this).next("ul").slideToggle(500);
    });

    //Disable dropdown parent link
    $(".navigation li.dropdown > a").on("click", function (e) {
      e.preventDefault();
    });

    //Disable dropdown parent link
    $(
      ".main-header .navigation li.dropdown > a,.hidden-bar .side-menu li.dropdown > a"
    ).on("click", function (e) {
      e.preventDefault();
    });
  }

  //Mobile Nav Hide Show
  if ($(".mobile-menu").length) {
    $(".mobile-menu .menu-box").mCustomScrollbar();

    var mobileMenuContent = $(".main-header .nav-outer .main-menu").html();
    $(".mobile-menu .menu-box .menu-outer").append(mobileMenuContent);
    $(".sticky-header .main-menu").append(mobileMenuContent);

    //Dropdown Button
    $(".mobile-menu li.dropdown .dropdown-btn").on("click", function () {
      $(this).toggleClass("open");
      $(this).prev("ul").slideToggle(500);
    });

    //Dropdown Button
    $(".mobile-menu li.dropdown .dropdown-btn").on("click", function () {
      $(this).toggleClass("open");
      $(this).prev(".mega-menu").slideToggle(500);
    });

    //Menu Toggle Btn
    $(".mobile-nav-toggler").on("click", function () {
      $("body").addClass("mobile-menu-visible");
    });

    //Menu Toggle Btn
    $(".mobile-menu .menu-backdrop,.mobile-menu .close-btn").on(
      "click",
      function () {
        $("body").removeClass("mobile-menu-visible");
      }
    );
  }

  //Parallax Scene for Icons
  if ($(".parallax-scene-1").length) {
    var scene = $(".parallax-scene-1").get(0);
    var parallaxInstance = new Parallax(scene);
  }
  if ($(".parallax-scene-2").length) {
    var scene = $(".parallax-scene-2").get(0);
    var parallaxInstance = new Parallax(scene);
  }
  if ($(".parallax-scene-3").length) {
    var scene = $(".parallax-scene-3").get(0);
    var parallaxInstance = new Parallax(scene);
  }
  if ($(".parallax-scene-4").length) {
    var scene = $(".parallax-scene-4").get(0);
    var parallaxInstance = new Parallax(scene);
  }
  if ($(".parallax-scene-5").length) {
    var scene = $(".parallax-scene-5").get(0);
    var parallaxInstance = new Parallax(scene);
  }
  if ($(".parallax-scene-6").length) {
    var scene = $(".parallax-scene-6").get(0);
    var parallaxInstance = new Parallax(scene);
  }
  if ($(".parallax-scene-7").length) {
    var scene = $(".parallax-scene-7").get(0);
    var parallaxInstance = new Parallax(scene);
  }
  if ($(".parallax-scene-8").length) {
    var scene = $(".parallax-scene-8").get(0);
    var parallaxInstance = new Parallax(scene);
  }
  if ($(".parallax-scene-9").length) {
    var scene = $(".parallax-scene-9").get(0);
    var parallaxInstance = new Parallax(scene);
  }
  if ($(".parallax-scene-10").length) {
    var scene = $(".parallax-scene-10").get(0);
    var parallaxInstance = new Parallax(scene);
  }

  //Datepicker
  if ($(".datepicker").length) {
    $(".datepicker").datepicker();
  }

  if ($(".paroller").length) {
    $(".paroller").paroller({
      factor: 0.2, // multiplier for scrolling speed and offset, +- values for direction control
      factorLg: 0.4, // multiplier for scrolling speed and offset if window width is less than 1200px, +- values for direction control
      type: "foreground", // background, foreground
      direction: "horizontal", // vertical, horizontal
    });
  }

  //Custom Seclect Box
  // if ($(".custom-select-box").length) {
  //   $(".custom-select-box")
  //     .selectmenu()
  //     .selectmenu("menuWidget")
  // }

  //Fact Counter + Text Count
  if ($(".count-box").length) {
    $(".count-box").appear(
      function () {
        var $t = $(this),
          n = $t.find(".count-text").attr("data-stop"),
          r = parseInt($t.find(".count-text").attr("data-speed"), 10);

        if (!$t.hasClass("counted")) {
          $t.addClass("counted");
          $({
            countNum: $t.find(".count-text").text(),
          }).animate(
            {
              countNum: n,
            },
            {
              duration: r,
              easing: "linear",
              step: function () {
                $t.find(".count-text").text(Math.floor(this.countNum));
              },
              complete: function () {
                $t.find(".count-text").text(this.countNum);
              },
            }
          );
        }
      },
      { accY: 0 }
    );
  }

  //Main Slider Carousel
  if ($(".main-slider-carousel").length) {
    $(".main-slider-carousel").owlCarousel({
      animateOut: "fadeOut",
      animateIn: "fadeIn",
      loop: true,
      margin: 0,
      nav: true,
      autoHeight: true,
      smartSpeed: 500,
      //   autoplay: 6000,
      navText: [
        '<span class="flaticon-back"></span>',
        '<span class="flaticon-next-1"></span>',
      ],
      responsive: {
        0: {
          items: 1,
        },
        600: {
          items: 1,
        },
        800: {
          items: 1,
        },
        1024: {
          items: 1,
        },
        1200: {
          items: 1,
        },
      },
    });
  }

  // Single Item Carousel
  if ($(".single-item-carousel").length) {
    $(".single-item-carousel").owlCarousel({
      loop: true,
      margin: 0,
      nav: true,
      smartSpeed: 500,
      autoplay: 4000,
      navText: [
        '<span class="fa fa-angle-left"></span>',
        '<span class="fa fa-angle-right"></span>',
      ],
      responsive: {
        0: {
          items: 1,
        },
        480: {
          items: 1,
        },
        600: {
          items: 1,
        },
        800: {
          items: 1,
        },
        1024: {
          items: 1,
        },
      },
    });
  }

  // Three Item Carousel
  if ($(".three-item-carousel").length) {
    $(".three-item-carousel").owlCarousel({
      loop: true,
      margin: 30,
      nav: true,
      smartSpeed: 500,
      autoplay: 4000,
      navText: [
        '<span class="fa fa-angle-left"></span>',
        '<span class="fa fa-angle-right"></span>',
      ],
      responsive: {
        0: {
          items: 1,
        },
        480: {
          items: 1,
        },
        600: {
          items: 2,
        },
        800: {
          items: 3,
        },
        1024: {
          items: 3,
        },
      },
    });
  }

  // Team Carousel
  if ($(".team-carousel").length) {
    $(".team-carousel").owlCarousel({
      loop: true,
      margin: 0,
      nav: true,
      center: true,
      smartSpeed: 500,
      autoplay: 4000,
      navText: [
        '<span class="fa fa-angle-left"></span>',
        '<span class="fa fa-angle-right"></span>',
      ],
      responsive: {
        0: {
          items: 1,
        },
        480: {
          items: 1,
        },
        600: {
          items: 2,
        },
        800: {
          items: 2,
        },
        1024: {
          items: 3,
        },
      },
    });
  }

  // Sponsors Item Carousel
  if ($(".sponsors-carousel").length) {
    $(".sponsors-carousel").owlCarousel({
      loop: true,
      margin: 30,
      nav: true,
      smartSpeed: 500,
      autoplay: 4000,
      navText: [
        '<span class="fa fa-angle-left"></span>',
        '<span class="fa fa-angle-right"></span>',
      ],
      responsive: {
        0: {
          items: 3,
        },
        480: {
          items: 3,
        },
        600: {
          items: 3,
        },
        800: {
          items: 4,
        },
        1024: {
          items: 5,
        },
      },
    });
  }

  //Accordion Box
  if ($(".accordion-box").length) {
    $(".accordion-box").on("click", ".acc-btn", function () {
      var outerBox = $(this).parents(".accordion-box");
      var target = $(this).parents(".accordion");

      if ($(this).next(".acc-content").is(":visible")) {
        //return false;
        $(this).removeClass("active");
        $(this).next(".acc-content").slideUp(300);
        $(outerBox).children(".accordion").removeClass("active-block");
      } else {
        $(outerBox).find(".accordion .acc-btn").removeClass("active");
        $(this).addClass("active");
        $(outerBox).children(".accordion").removeClass("active-block");
        $(outerBox).find(".accordion").children(".acc-content").slideUp(300);
        target.addClass("active-block");
        $(this).next(".acc-content").slideDown(300);
      }
    });
  }

  //LightBox / Fancybox
  if ($(".lightbox-image").length) {
    $(".lightbox-image").fancybox({
      openEffect: "fade",
      closeEffect: "fade",
      helpers: {
        media: {},
      },
    });
  }

  //Contact Form Validation
  if ($("#contact-form").length) {
    $("#contact-form").validate({
      rules: {
        username: {
          required: true,
        },
        email: {
          required: true,
          email: true,
        },
        subject: {
          required: true,
        },
        message: {
          required: true,
        },
      },
    });
  }

  // Scroll to a Specific Div
  if ($(".scroll-to-target").length) {
    $(".scroll-to-target").on("click", function () {
      var target = $(this).attr("data-target");
      // animate
      $("html, body").animate(
        {
          scrollTop: $(target).offset().top,
        },
        1500
      );
    });
  }

  // Elements Animation
  if ($(".wow").length) {
    var wow = new WOW({
      boxClass: "wow", // animated element css class (default is wow)
      animateClass: "animated", // animation css class (default is animated)
      offset: 0, // distance to the element when triggering the animation (default is 0)
      mobile: true, // trigger animations on mobile devices (default is true)
      live: true, // act on asynchronously loaded content (default is true)
    });
    wow.init();
  }

  /* ==========================================================================
   When document is Scrollig, do
   ========================================================================== */

  $(window).on("scroll", function () {
    headerStyle();
  });

  /* ==========================================================================
   When document is loading, do
   ========================================================================== */

  $(window).on("load", function () {
    handlePreloader();
  });

  /* ==========================================================================
   Tab Version Home 2 contact us styling
   ========================================================================== */

  var mediaScreen = $(window).width();

  if (mediaScreen > 600 && mediaScreen < 1590) {
    var selected = $(
      ".home-2 .contact-us-home-2 .auto-container .home-2-contact-us-container .home-2-contact-us-left .icon-container"
    );

    var selected_2 = $(
      ".home-2 .contact-us-home-2 .auto-container .home-2-contact-us-container .home-2-contact-us-right .contact-us"
    );
    var itsLength = selected.width() + 30;
    selected_2.css("margin-left", itsLength);
  }

  var logoselected = $(
    ".home-2 .main-header .header-upper .logo-box .logo a img"
  );

  if (mediaScreen < 1024) {
    var getval = logoselected.attr("src", "images/logo.png");
  } else if (mediaScreen > 992) {
    logoselected.attr("src", "images/logo-white.png");
  }

  var selectedimagebox = $(".main-slider .image-column");
  var selectedbottom = $(".main-slider .content-column .slide-arrow");

  if (mediaScreen <= 992) {
    var height = selectedimagebox.height() + 82;

    selectedbottom.css("bottom", "-" + height + "px");
  }

  var onHover = $(".calculator-palate .calculator-trigger");
  var targetted = $(".calculator-palate .palate-tag");
  onHover.on("mouseover", function () {
    targetted.addClass("active");
  });

  onHover.on("mouseleave", function () {
    targetted.removeClass("active");
  });

  var onHoverContact = $(".cantact-palate .calculator-trigger");
  var targettedCalc = $(".cantact-palate .palate-tag");
  onHoverContact.on("mouseover", function () {
    targettedCalc.addClass("active");
  });

  onHoverContact.on("mouseleave", function () {
    targettedCalc.removeClass("active");
  });

  var calcCont = $(".calculator-palate");
  var contactCont = $(".cantact-palate");

  onHoverContact.on("click", function () {
    calcCont.removeClass("visible-palate");
  });

  onHover.on("click", function () {
    contactCont.removeClass("visible-palate");
  });

  //Mobile Nav Hide Show
  if ($(".mobile-menu").length) {
    //Dropdown Button
    $(".home-2 .mobile-menu li.dropdown .dropdown-btn").on(
      "click",
      function () {
        $(this).prev("ul").slideToggle();
        $(this).toggleClass("open");
      }
    );

    //Dropdown Button
    $(".home-2 .mobile-menu li.dropdown .dropdown-btn").on(
      "click",
      function () {
        // $(this).toggleClass("open");
        // $(this).prev(".mega-menu").slideToggle(500);
      }
    );

    //Menu Toggle Btn
    $(".home-2 .mobile-nav-toggler").on("click", function () {
      $("body").addClass("mobile-menu-visible");
    });

    //Menu Toggle Btn
    $(".home-2 .mobile-menu .menu-backdrop,.mobile-menu .close-btn").on(
      "click",
      function () {
        $("body").removeClass("mobile-menu-visible");
      }
    );
  }
  
  
  /* ==========================================================================
   copyright year change
   ========================================================================== */	
	
function walkText(node) {
		
	var	date = (new Date()).getFullYear();

  if (node.nodeType == 3) {
    node.data = node.data.replace(/2021/g, date);
  }
  if (node.nodeType == 1 && node.nodeName != "SCRIPT") {
    for (var i = 0; i < node.childNodes.length; i++) {
      walkText(node.childNodes[i]);
    }
  }
}
var copyrightReplace = document.querySelector('.copyright');
walkText(copyrightReplace);
  
  
})(window.jQuery);
