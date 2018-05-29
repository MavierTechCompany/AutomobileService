const dragDrop = document.querySelector('#drag-drop');
const windowCloseButton = document.querySelector('.drag-drop-window__close');
const pageCover = document.querySelector('#page-cover');
const dragDropWindow = document.querySelector('#drag-drop-window')
let dragDropClosed = document.querySelector('#drag-drop--closed');
let dragDropOpened = document.querySelector('#drag-drop--opened');

function dragDropOpen(){
    let dragDropClosed = document.querySelector('#drag-drop--closed');
    dragDropClosed.id="drag-drop--opened";
    pageCover.style.width = '100%';
    dragDropWindow.style.display = 'inline';
}

function dragDropClose(){
    let dragDropOpened = document.querySelector('#drag-drop--opened');
    dragDropOpened.id="drag-drop--closed";
    pageCover.style.width = '0';
    dragDropWindow.style.display = "none";
}

dragDrop.onclick = dragDropOpen;
windowCloseButton.onclick = dragDropClose;
pageCover.onclick = dragDropClose;
document.addEventListener('keydown', function(event) { if (event.keyCode == 27) dragDropClose(); }, true);