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
    if(document.getElementById('dropdown--close')){
      document.getElementById('dropdown--close').id="dropdown--open"
      document.getElementById('dropdown__content--close').id="dropdown__content--open"
    }
    else if(document.getElementById('dropdown--open')){
        document.getElementById('dropdown--open').id="dropdown--close"
        document.getElementById('dropdown__content--open').id="dropdown__content--close"
    }
}


//sidebar

function SlideMenu(){
    if(document.getElementById('hamburger--close')){
        document.getElementById('hamburger--close').id="hamburger--open"
        
        const mq = window.matchMedia( "(max-width: 720px)" );
        if (mq.matches) {
        // window width is at least 720px
        document.getElementById('side-menu').style.width = '100%';
        } 
        else {
        // window width is less than 720px
        document.getElementById('side-menu').style.width = '250px';
        }
        //document.getElementById('scale').style.marginLeft = '250px';
    }
    else if(document.getElementById('hamburger--open')){
        document.getElementById('hamburger--open').id="hamburger--close"
        document.getElementById('side-menu').style.width = '0';
        //document.getElementById('scale').style.marginLeft = '0';
    }
}


function elementClose(){
    document.getElementById('hamburger--open').id="hamburger--close"
    document.getElementById('side-menu').style.width = '0';

    document.getElementById('dropdown--open').id="dropdown--close"
    document.getElementById('dropdown__content--open').id="dropdown__content--close"
}