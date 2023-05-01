


$(document).ready(function () {

    if ($("html").attr('dir') == "rtl") {

   

        $(".searchBtn").css({
            "left": "10%",
            "border-right": " 1px solid #231c1c"
        });

        $(".optionMenu").css({
            "left": "10%",

        })
    } else {
        $(".searchBtn").css({
            "right": "10%",
            "border-left": " 1px solid #231c1c"
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










})

