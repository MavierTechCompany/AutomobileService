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

window.addEventListener('scroll', stickyNavigation);


//dropdown

function dropdownMenu() {
    let dropdownClosed = document.getElementById('dropdown--close');
    let dropdownOpened = document.getElementById('dropdown--open');
    if(dropdownClosed){
      dropdownClosed.id="dropdown--open";
      document.getElementById('dropdown__content--close').id="dropdown__content--open";
    }
    else if(dropdownOpened){
        dropdownOpened.id="dropdown--close";
        document.getElementById('dropdown__content--open').id="dropdown__content--close";
    }
}


//sidebar



function SlideMenu(){
    let hamburgerClosed = document.getElementById('hamburger--closed');
    let hamburgerOpened = document.getElementById('hamburger--opened');
    let sidebar = document.getElementById('side-menu');
    let mobileWidth = window.matchMedia( "(max-width: 720px)" );

    if (hamburgerClosed){
        hamburgerClosed.id="hamburger--opened";
        if (mobileWidth.matches) {
            sidebar.style.width = '100%';
        }
        else {
            sidebar.style.width = '250px';
        }
    }
    else if (hamburgerOpened){
        hamburgerOpened.id="hamburger--closed";
        sidebar.style.width = '0';
    }
}



var hamburger = {
    disabled: document.getElementById('hamburger--closed'),
    active: document.getElementById('hamburger--opened'),
    
}





function elementClose(){
    let hamburgerOpened = document.getElementById('hamburger--opened');
    let sidebar = document.getElementById('side-menu');
    let dropdownOpened = document.getElementById('dropdown--open');

    hamburgerOpened.id="hamburger--closed";
    sidebar.style.width = '0';
    dropdownOpened.id="dropdown--close";
    document.getElementById('dropdown__content--open').id="dropdown__content--close";
}