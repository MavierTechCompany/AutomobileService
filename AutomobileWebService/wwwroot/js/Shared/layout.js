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

function pageMenu(){
    document.getElementById('hamburger--open').id="hamburger--close"
    document.getElementById('side-menu').style.width = '0';
}