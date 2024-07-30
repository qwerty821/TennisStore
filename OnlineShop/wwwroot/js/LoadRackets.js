window.onload = ApplyFilter();

function showOrHideFilter() {
    var e = document.getElementById("sidenav");

    if (e.classList.contains('show')) {
        e.classList.remove('show');
        e.classList.add('hide');
        console.log("1");
    } else {
        if (e.classList.contains('hide')) {
            e.classList.remove('hide');
        }
        e.classList.add('show');
        console.log("2");
    }
}
function ApplyFilter(mobile) {
    if (mobile != null) {
        showOrHideFilter();
    }
    var filters = GetFilters();
    UpdateRacketsContent(filters);
}

function GetFilters() {
    var filters = {
        'brands': [],
        'sort': 'def'
    };
    var elements = document.getElementsByClassName("filter-option");
    for (let e of elements) {
        if (e.checked) {
            filters.brands.push(e.getAttribute('name'));
        }
    }

    elements = document.getElementsByClassName("sort-button");
    for (let i = 0; i < elements.length; i++) {
        if (elements[i].getAttribute('data-selected') == '1') {
            filters.sort = elements[i].getAttribute('data-sort');
        }
    }

    return filters;
}

function closeFilter() {
    var cbox = document.getElementsByClassName("filter-body")[0];
    if (cbox.style.display == "block") {
        cbox.style.display = "none";
    } else {
        cbox.style.display = "block";
    }
}

function ShowRackets(data) {
    var racketContent = document.getElementById("racket-content");
    racketContent.innerHTML = "";
    if (data == null) return;

    for (let x of data) {
        racketContent.innerHTML += `\
        <section class ="racket-section">
            <div>
                <a href="/edit-racket/${x["id"]}">
                    <button type="button" class="btn btn-danger edit-racket">
                        Edit
                    </button>
                </a>
            </div>
            <a class="a-racket" href="/racket/${x["id"]}"> \
                <div class="card" style = "width: 18rem;" > \
                    <img src="${x["imageUrl"]}" class="card-img-top" alt=""> \
                        <span class="racket-brand"> \
                           ${x["brand"]} \
                        </span> \
                        <div class="card-body"> \
                            <span class="racket-name">${x["name"]}</span> \
                            <div class="racket-price">${x["price"]}$</div> \
                        </div> \
                </div> \
            </a > \
        </section>
        `
    }
}

function GetRacketsByFilter(filterList) {
    var data = {
        'brand': filterList.brands,
        'sort': filterList.sort
    }

    var url = `/all-rackets?${new URLSearchParams(data).toString()}`;

    return fetch(url, {
        method: "GET"
    }).then((res) => {
        return res.json();
    }).then((data) => {
        return data;
    });
}
async function UpdateRacketsContent(filterList) {
    var jsonObj = await GetRacketsByFilter(filterList);
    ShowRackets(jsonObj);
}

function SortData(event) {
    var x = document.getElementsByClassName("sort-button");

    for (let i = 0; i < x.length; i++) {
        if (x[i].getAttribute('data-selected') == '1') {
            x[i].setAttribute('data-selected', '0');
        }
    }
    event.target.setAttribute('data-selected', '1');

    ApplyFilter();
}