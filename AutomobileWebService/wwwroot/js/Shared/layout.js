//navbar scroll

const nav = document.querySelector('#navigation');
const navTop = nav.offsetTop;

function stickyNavigation() {
    console.log('navTop = ' + navTop);
    console.log('scrollY = ' + window.scrollY);

    if (window.scrollY >= navTop) {
        // nav offsetHeight = height of nav
        document.body.style.paddingTop = nav.offsetHeight + 'px';
        document.body.classList.add('fixed-nav');
    } 
    else {
        document.body.style.paddingTop = 0;
        document.body.classList.remove('fixed-nav');
    }
}

//dropdown

var userButton = document.querySelector('#navbar__user-menu__container');
var pageContent = document.querySelector('#page-content');
var pageCover = document.querySelector('#page-cover');
var navbar = document.querySelector('#navigation');
var hamburger = document.querySelector('#hamburger');


function dropdownMenu() {
    let dropdownClosed = document.querySelector('#dropdown--closed');
    let dropdownOpened = document.querySelector('#dropdown--opened');
    let arrowDown = document.querySelector('.fa-chevron-down');
    let arrowUp = document.querySelector('.fa-chevron-up');
    if(dropdownClosed){
        document.querySelector("#dropdown__content").style.cssText = null;
        dropdownClosed.id="dropdown--opened";
        arrowDown.classList.remove("fa-chevron-down");
        arrowDown.classList.add("fa-chevron-up");
        
    }
    else if(dropdownOpened){
        document.querySelector('#dropdown__content').style.display = "none";
        dropdownOpened.id="dropdown--closed";
        arrowUp.classList.remove("fa-chevron-up");
        arrowUp.classList.add("fa-chevron-down");
    }
}


function dropdownMenuClose(){
    let dropdownOpened = document.querySelector('#dropdown--opened');
    let arrowDown = document.querySelector('.fa-chevron-down');
    let arrowUp = document.querySelector('.fa-chevron-up');
    document.querySelector('#dropdown__content').style.display = "none";
    dropdownOpened.id="dropdown--closed";
    arrowUp.classList.remove("fa-chevron-up");
    arrowUp.classList.add("fa-chevron-down");
}

//sidebar


function sideMenu(){
    let hamburgerClosed = document.querySelector('#hamburger--closed');
    let hamburgerOpened = document.querySelector('#hamburger--opened');
    let sidebar = document.querySelector('#side-menu');
    let pageCover = document.querySelector('#page-cover');
    let mobileWidth = window.matchMedia( "(max-width: 720px)" );

    if (hamburgerClosed){
        hamburgerClosed.id="hamburger--opened";
        if (mobileWidth.matches) {
            sidebar.style.width = '100%';
        }
        else {
            sidebar.style.width = '250px';
        }
        pageCover.style.width = '100%';
    }
    else if (hamburgerOpened){
        hamburgerOpened.id="hamburger--closed";
        sidebar.style.width = '0';
        pageCover.style.width = '0';
        pageContent.style.cssText = null;
    }
}


window.addEventListener('scroll', stickyNavigation);
hamburger.onclick = sideMenu;
pageContent.onclick = dropdownMenuClose;
pageCover.onclick = sideMenu;
userButton.onclick = dropdownMenu;