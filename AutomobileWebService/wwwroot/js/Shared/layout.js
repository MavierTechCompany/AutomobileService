const userButton = document.querySelector('#navbar__user-menu__container');
const pageContent = document.querySelector('#page-content');
const pageCover = document.querySelector('#page-cover');
const navbar = document.querySelector('#navigation');
const hamburger = document.querySelector('#hamburger');
const mobileWidth = window.matchMedia( "(max-width: 720px)" );


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

function dropdownMenu() {
    let dropdownClosed = document.querySelector('#dropdown--closed');
    let dropdownOpened = document.querySelector('#dropdown--opened');
    let arrowDown = document.querySelector('.fa-chevron-down');
    let arrowUp = document.querySelector('.fa-chevron-up');
    
    if(dropdownClosed){
        dropdownMenuOpen();
    }
    else if(dropdownOpened){
        dropdownMenuClose();
    }
}

function dropdownMenuOpen(){
    let dropdownClosed = document.querySelector('#dropdown--closed');
    let dropdownOpened = document.querySelector('#dropdown--opened');
    let arrowDown = document.querySelector('.fa-chevron-down');
    let arrowUp = document.querySelector('.fa-chevron-up');

    if (mobileWidth.matches) {
        document.querySelector("#dropdown__content-mobile").style.cssText = null;
    }
    else{
        document.querySelector("#dropdown__content").style.cssText = null;
    }
    dropdownClosed.id="dropdown--opened";
    arrowDown.classList.remove("fa-chevron-down");
    arrowDown.classList.add("fa-chevron-up");
    if (mobileWidth.matches) {
        pageCover.style.width = '100%';
    }
    sideMenuClose();
}

function dropdownMenuClose(){
    let hamburgerClosed = document.querySelector('#hamburger--closed');
    let dropdownOpened = document.querySelector('#dropdown--opened');
    let arrowDown = document.querySelector('.fa-chevron-down');
    let arrowUp = document.querySelector('.fa-chevron-up');


    if (mobileWidth.matches) {
        document.querySelector("#dropdown__content-mobile").style.display = "none";
    }
    else{
        document.querySelector("#dropdown__content").style.display = "none";
    }
    dropdownOpened.id="dropdown--closed";
    arrowUp.classList.remove("fa-chevron-up");
    arrowUp.classList.add("fa-chevron-down");
    if (mobileWidth.matches && hamburgerClosed) {
        pageCover.style.width = '0';
    }
}


//sidebar

function sideMenu(){
    let hamburgerClosed = document.querySelector('#hamburger--closed');
    let hamburgerOpened = document.querySelector('#hamburger--opened');
    let sidebar = document.querySelector('#side-menu');
    // let hamburgerStatus = 'active';

    if (hamburgerClosed){
        sideMenuOpen();
    }
    else if (hamburgerOpened){
        sideMenuClose();
    }
}

function sideMenuOpen(){
    let hamburgerClosed = document.querySelector('#hamburger--closed');
    let hamburgerOpened = document.querySelector('#hamburger--opened');
    let sidebar = document.querySelector('#side-menu');

    hamburgerClosed.id="hamburger--opened";
    if (mobileWidth.matches) {
        sidebar.style.width = '100%';
    }
    else {
        sidebar.style.width = '240px';
    }
    pageCover.style.width = '100%';
    dropdownMenuClose();
}


function sideMenuClose(){
    let dropdownClosed = document.querySelector('#dropdown--closed');
    let hamburgerOpened = document.querySelector('#hamburger--opened');
    let sidebar = document.querySelector('#side-menu');

    hamburgerOpened.id="hamburger--closed";
    sidebar.style.width = '0';
    if(dropdownClosed){
        pageCover.style.width = '0';
    }
    pageContent.style.cssText = null;
}


document.addEventListener('keydown', function(event) { if (event.keyCode == 27) sideMenuClose(); }, true);
window.addEventListener('scroll', stickyNavigation);
hamburger.onclick = sideMenu;
pageContent.onclick = dropdownMenuClose;
pageCover.onclick = sideMenu;
userButton.onclick = dropdownMenu;