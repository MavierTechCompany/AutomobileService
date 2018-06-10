const pageCover = document.querySelector('#page-cover');
const userButton = document.querySelector('#navbar__user-menu__container');
const pageContent = document.querySelector('#page-content');
const hamburger = document.querySelector('#hamburger');
const mobileWidth = window.matchMedia( "(max-width: 720px)");
const mediumWidth = window.matchMedia('(min-width: 740px)');
const sidebar = document.querySelector('#side-menu');
const navbar = document.querySelector('.navbar');

const nav = document.querySelector('#navigation');
const navTop = nav.offsetTop;


function pageCoverVisibility (width) {
    pageCover.style.width = width;
}


function stickyNavigation() {
    // console.log('navTop = ' + navTop);
    // console.log('scrollY = ' + window.scrollY);

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


function dropdownMenu() {
    let dropdownClosed = document.querySelector('#dropdown--closed');
    let dropdownOpened = document.querySelector('#dropdown--opened');
    
    if(dropdownClosed){
        dropdownMenuOpen();
    }
    else if(dropdownOpened){
        dropdownMenuClose();
    }
}

function dropdownMenuOpen(){
    let dropdownClosed = document.querySelector('#dropdown--closed');
    let arrowDown = document.querySelector('.fa-chevron-down');

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
        pageCoverVisibility('100%');
    }
    sideMenuClose();
}

function dropdownMenuClose(){
    let hamburgerClosed = document.querySelector('#hamburger--closed');
    let dropdownOpened = document.querySelector('#dropdown--opened');
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
        pageCoverVisibility('0');
    }
}


function sideMenu(){
    let hamburgerClosed = document.querySelector('#hamburger--closed');
    let hamburgerOpened = document.querySelector('#hamburger--opened');

    if (hamburgerClosed){
        sideMenuOpen();
    }
    else if (hamburgerOpened){
        sideMenuClose();
    }
}

function sideMenuOpen(){
    let hamburgerClosed = document.querySelector('#hamburger--closed');

    hamburgerClosed.id="hamburger--opened";
    if (mobileWidth.matches) {
        sidebar.style.width = '100%';
    }
    else {
        sidebar.style.width = '240px';
    }
    pageCoverVisibility('100%');
    dropdownMenuClose();
}

function sideMenuClose(){
    let dropdownClosed = document.querySelector('#dropdown--closed');
    let hamburgerOpened = document.querySelector('#hamburger--opened');

    hamburgerOpened.id="hamburger--closed";
    sidebar.style.width = '0';
    if(dropdownClosed || !mobileWidth.matches){
        pageCoverVisibility('0');
    }
    pageContent.style.cssText = null;
}



var previousScrollTop;
var isScrolling;
var searchbar = document.querySelector('.searchbar');

function hasScrolled() {
  
  var scrollTop = window.scrollY;
  
  if (scrollTop > previousScrollTop){
    searchbar.classList.add('searchbar--up');
    navbar.classList.add('navbar__shadow');
  } else {
    searchbar.classList.remove('searchbar--up');
    navbar.classList.remove('navbar__shadow');
  }
    
  previousScrollTop = scrollTop;
  
  if(mediumWidth.matches){
    navbar.classList.add('navbar__shadow');
  }

}

document.addEventListener('scroll', function() {
  isScrolling = true;
}, false);

setInterval(function() {
  if (isScrolling) {
    hasScrolled();
    isScrolling = false;
  }
}, 100);









window.addEventListener('scroll', stickyNavigation);
userButton.onclick = dropdownMenu;
pageContent.onclick = dropdownMenuClose;
hamburger.onclick = sideMenu;
pageCover.onclick = sideMenuClose;
document.addEventListener('keydown', function(event) { if (event.keyCode == 27) sideMenuClose(); }, true);