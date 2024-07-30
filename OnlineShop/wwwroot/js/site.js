// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

/// Edit Racket start /// 

function setValues(r, b) {
    var e = document.getElementById("brands");

    for (let x of b) {
        e.innerHTML += `<option value="${x.name}">${x.name}</option>`;
    }
    document.getElementById("Id").value = r.id;
    document.getElementById("Name").value = r.name;
    document.getElementById("Price").value = r.price;
    document.getElementById("ImageUrl").value = r.imageUrl;
    document.getElementById("brands").value = r.brand;

    document.getElementById("edit-r-def-img").innerHTML += `<section class="racket-section">
                        <div>
                            <div class="position-absolute top-0 end-0 edit-but">
                               
                                <div style="width:50px; height:50px; cursor:pointer;">
                                    <img src="/img/icons8-edit-50.png" style="margin:0px; width: inherit; height: inherit;" />
                                </div>
                            </div>
                        </div>
                        <img src="${r.imageUrl}" />
                    </section>`
    

    initRacket(r);
    showRacketImages();

}

var _racket = undefined;
var firstGet = true;
function initRacket(r) {
    _racket = r;
}

async function showRacketImages() {
    if (firstGet != true) {
        if (_racket != undefined) {
            _racket = await GetRacket(_racket.id);
        }
    }
    if (_racket.images.length > 0) {
        var imgs = document.getElementById("edit-r-img");
        imgs.innerHTML = "";
        for (let x of _racket.images) {
            imgs.innerHTML += `<section class="racket-section">
                        <div>
                            <div class="position-absolute top-0 end-0 edit-but">
                                <div style="width:30px; height:30px; cursor:pointer;" onclick="RemoveImg('${x.id}')">
                                    <img src="/img/icons8-x-button-48.png" style="margin:0px; width: inherit; height: inherit;" />
                                </div>  
                                <div style="width:50px; height:50px; cursor:pointer;" onclick="SetAttributes('edit', '${x.id}')">
                                    <img src="/img/icons8-edit-50.png" style="margin:0px; width: inherit; height: inherit;" />
                                </div>
                            </div>
                        </div>
                        <img src="${x.imageUrl}" />
                    </section>`
        }
        
    }
        
    firstGet = false;
}

async function SetAttributes(attrType, value) {
    document.getElementById("userInput").setAttribute("data-type", attrType);
    if (value == undefined) {
        var r = await GetRacket(GetIdFromUrl(window.location.href));
        value = r.id;
    }  

    document.getElementById("userInput").setAttribute("data-id", value);
     
    ShowInput();
}

async function RemoveImg(id) {
    var data = {
        'id': id
    }

    await SendData("/image/remove", data);

    showRacketImages();
}

async function AddImage(racket_id, imageUrl) {

    SaveImage(racket_id, imageUrl);
    showRacketImages();
}

function ShowInput() {
    document.getElementById("customAlert").style.display = "block";
}


function GetRacket(id) {
    var data = {
        'id': id
    }
    var url = `/get-racket?${new URLSearchParams(data).toString()}`;

    return fetch(url, {
        method: "GET"
    }).then((res) => {
        return res.json();
    }).then((data) => {
        return data;
    });
}

function GetIdFromUrl(url) {

    var pathname = new URL(url).pathname;

    var segments = pathname.split('/');
    var id = segments[segments.length - 1];
    return id;

}

async function EditImg(id, imageUrl) {

    var data = {
        "id": id,
        "imageUrl": imageUrl
    }
    var url = "/image/edit";
    await SendData(url, data);
    showRacketImages();
}

async function GetBrands() {
    return await fetch("/get-brands", {
        method: "GET"
    }).then((res) => {
        return res.json();
    }).then((data) => {
        return data;
    });

}
async function SendData(u, data) {

    var url = `${u}?${new URLSearchParams(data).toString()}`;

    await fetch(url, {
        method: "Post"
    });
    
}

async function GetData(u, data) {

    var url = `${u}?${new URLSearchParams(data).toString()}`;

    return await fetch(url, {
        method: "GET"
    }).then((res) => {
        return res.json();
    }).then((data) => {
        return data;
    });

}

async function GetImage(id) {
    var data =  {
        "id" : id
    }

    var x = await GetData("/image", data);
}

async function SaveImage(r_id, url) {
    var data = {
        "racket_id": r_id,
        "ImageUrl": url
    }
    var x = await SendData("/image/add", data);
}

