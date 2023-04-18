// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// adming page







const myCarouselElement = document.querySelector('#myCarousel')

const carousel = new bootstrap.Carousel(myCarouselElement);


const humburg = document.getElementById("humburg");
const sumMenu = document.querySelector(".subMenu");
let  toggler = false;
humburg.addEventListener("click", function () {
    toggler = !toggler;
    if (toggler) {
        sumMenu.style.top = "0";
        sumMenu.style.opacity = "100";

    } else {
        sumMenu.style.top = "-100%";
        sumMenu.style.opacity = "0";
 
    }
    console.log(toggler);
})

$(document).ready(function () {

    // hide navbar on scroll
    $(window).scroll(function () {
        let scroll = $(window).scrollTop();

        if (scroll > 100) {
            $(".NavHeader").fadeOut();

        } else {
            $(".NavHeader").fadeIn();
        }
    })
    // post images slider
   
    const Dir = document.documentElement.getAttribute("dir");


    $('.owl-carousel').owlCarousel({
        loop: true,
        margin: 10,
        nav: true,
        dots: true,
        rtl: Dir == "rtl" ? true : false,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 2
            },
            1000: {
                items: 3
            },
            1300: {
                items: 4
            }
        }
    })
});






    function animateNumber(start, end, duration, elem) {
        let current = start;
        let increment = (end - start) / duration;

        /* let elem = document.querySelectorAll(".riseNum");*/



        let timer = setInterval(function () {
            current += increment;
            elem.innerHTML = Math.round(current);
            if (current >= end) {
                clearInterval(timer);
            }
        }, 10);

    
    }



    //let teamNumber = document.querySelector(".teamNumber");
    //let benef = document.querySelector(".benef");
    //let activ = document.querySelector(".Activities");
    //let comm = document.querySelector(".Committees");

    //animateNumber(0, +teamNumber.innerHTML, 500, teamNumber);
    //animateNumber(0, +benef.innerHTML, 500, benef);
    //animateNumber(0, +comm.innerHTML, 500, activ);
    //animateNumber(0, +activ.innerHTML, 500, comm);


// gsap functinos

gsap.registerPlugin(ScrollTrigger);
let items = document.querySelectorAll(".riseNum");

/*const items = document.querySelectorAll(".data");*/

gsap.from(items, {
    scrollTrigger:"items",
    textContent: 0,
    duration:3 ,
    ease: "power1.in",
    snap: { textContent: 1 },
    stagger: {
        each: 1.0,
        onUpdate: function () {
            this.targets()[0].innerHTML = numberWithCommas(Math.ceil(this.targets()[0].textContent));
        },
    }
});


function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}