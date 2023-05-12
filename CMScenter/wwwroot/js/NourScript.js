let current = localStorage.getItem("theme");
document.body.classList.add(current);
$(document).ready(function () {


    if ($("html").attr('dir') == "rtl") {
        if ($("ToogleId").hasClass("rightToggle")) {

            $("#ToogleId").removeClass("rightToggle");
        }
        $("#ToogleId").addClass("leftToggle");
        $(".searchBtn").css({
            "left": "10%",
            "border-right": " 1px solid #231c1c",
               "border-top-left-radius": "21px",
            "border-bottom-left-radius": "21px"
        });

        $(".optionMenu").css({
            "left": "10%",

        })

    } else {
        if ($("ToogleId").hasClass("leftToggle")) {

            $("#ToogleId").removeClass("leftToggle");
        }
        $("#ToogleId").addClass("rightToggle");
        console.log("left");
      
        $(".searchBtn").css({
            "right": "10%",
            "border-left": " 1px solid #231c1c",
             "border-top-right-radius": "21px",
             "border-bottom-right-radius": "21px"

        })
        $(".optionMenu").css({
            "right": "10%",

        })
    }

    //...
    let visible = false;
    $(".userOptions").click(function () {

        visible = !visible;
      
        if (visible) {

            $(".optionMenu").css({

                "display": "block",
                "opacity": "100",

            })
        } else {
            $(".optionMenu").css({

                "display": "none",
                "opacity": "0",

            })
        }

    })

    // activeNavItem
    let activeId = '';
    $("#activeNavItem ul li a").click(function () {
        $("#activeNavItem ul li").removeClass("active");

        $(this).parent("li").addClass("active");
        activeId = $(this).parent("li").attr("id");
        localStorage.setItem("activeId", activeId);

      

    })

    activeId = localStorage.getItem('activeId');
    if (activeId) {
        $('#' + activeId).addClass('active');
    }

    //.......................

    let long = false;
    $(".videoDes").click(function () {
        long = !long;
        if (long) {
            $(".videoDes").css({
                "white-space": "nowrap",
                "height": "5rem"
            });
            $(".videoDes p ").css({
                "white-space": "nowrap"
            });
        } else {
            $(".videoDes").css({
                "white-space": "normal",
                "height": "fit-content"
            });
            $(".videoDes p ").css({
                "white-space": "normal"
            });
        }
     
    })









})

const toggle = document.querySelector('#toggle');
let theme = false;

toggle.addEventListener('change', () => {
  
    document.body.classList.toggle('dark');
    //document.querySelector(".HomeNav").classList.toggle('dark');

    if (document.body.classList.contains("dark")) {

        localStorage.setItem("theme", "dark");
    } else {

        localStorage.setItem("theme", "light");
    }
})