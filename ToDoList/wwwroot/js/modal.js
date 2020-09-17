const addModal = document.querySelector(".add__modal .modal");
const addButton = document.querySelector(".header .add__btn");

const toDoItems = document.querySelectorAll(".task__info");
const closeModelBtns = document.querySelectorAll(".close");
const modalWindows = document.querySelectorAll(".modal");

addButton.addEventListener('click', (e) => {
   addModal.style.display = "block"; 
});

closeModelBtns.forEach(btn => {
   btn.addEventListener("click", () => {
      findOpenedWidow().style.display = "none";
   });
});

function findOpenedWidow() {
    for (let wind of modalWindows) {
        if (wind.style.display === "block") {
            return wind;
        }
    }
}

window.addEventListener('click', (event) => {
    let openedWindow = findOpenedWidow();
    if (event.target === openedWindow) {
        openedWindow.style.display = "none";
    }
});

toDoItems.forEach(item => {
    item.addEventListener("click", () => {
        let editWindowId = item.getAttribute("data-modal-id");
        let editWindow = document.getElementById(editWindowId);
        editWindow.style.display = "block";
    });
});