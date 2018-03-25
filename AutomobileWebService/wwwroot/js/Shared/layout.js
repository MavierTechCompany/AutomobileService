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

var userButton = document.getElementById('navbar__user-menu__container');
var pageContent = document.getElementById('page-content');
var pageCover = document.getElementById('page-cover');
var navbar = document.getElementById('navigation');
var hamburger = document.getElementById('hamburger');


function dropdownMenu() {
    let dropdownClosed = document.getElementById('dropdown--closed');
    let dropdownOpened = document.getElementById('dropdown--opened');
    if(dropdownClosed){
        document.getElementById("dropdown__content").style.cssText = null;
        dropdownClosed.id="dropdown--opened";
    }
    else if(dropdownOpened){
        document.getElementById("dropdown__content").style.display = "none";
        dropdownOpened.id="dropdown--closed";
    }
}

//sidebar


function sideMenu(){
    let hamburgerClosed = document.getElementById('hamburger--closed');
    let hamburgerOpened = document.getElementById('hamburger--opened');
    let sidebar = document.getElementById('side-menu');
    let pageCover = document.getElementById('page-cover');
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


function dropdownMenuClose(){
    let dropdownOpened = document.getElementById('dropdown--opened');
    document.getElementById("dropdown__content").style.display = "none";
    dropdownOpened.id="dropdown--closed";
}


window.addEventListener('scroll', stickyNavigation);
hamburger.onclick = sideMenu;
pageContent.onclick = dropdownMenuClose;
pageCover.onclick = sideMenu;
userButton.onclick = dropdownMenu;