
const imgs = document.querySelectorAll('.img-select a');
const imgBtns = [...imgs];
let imgId = 1;

imgBtns.forEach((imgItem) => {
    imgItem.addEventListener('click', (event) => {
        event.preventDefault();
        imgId = imgItem.dataset.id;
        slideImage();
    });
});

function slideImage() {
    const displayWidth = document.querySelector('.img-showcase img:first-child').clientWidth;

    document.querySelector('.img-showcase').style.transform = `translateX(${- (imgId - 1) * displayWidth}px)`;
}

window.addEventListener('resize', slideImage);


window.onload = showRacketPanel();
async function showRacketPanel() {
    var id = GetIdFromUrl(window.location.href);
    var r = await GetRacket(id);

    showRacketImages(r);
    showRacketsInfo(r);
}

function showRacketImages(r) {

    var pr1 = document.getElementsByClassName("r-img1");
    var pr2 = document.getElementsByClassName("r-img2");
    for (let i = 0; i < 4; i++) {
        if (r.images.length > i) {
            pr1[i].src = `${r.images[i].imageUrl}`
            pr2[i].src = `${r.images[i].imageUrl}`
        }
    }

} 

function showRacketsInfo(r) {
    document.getElementsByClassName("current-price")[0].innerHTML += `${r.price}`;
    document.getElementsByClassName("product-link")[0].innerHTML = `Visit ${r.brand} store`;
    document.getElementsByClassName("product-title")[0].innerHTML = `${r.name}`;

} 