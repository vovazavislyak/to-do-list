const addModal = document.querySelector("#add__modal");
const addButton = document.querySelector(".add__btn");
const closeAddButton = document.querySelector(".close");

addButton.addEventListener('click', (e) => {
   addModal.style.display = "block"; 
});

closeAddButton.addEventListener('click', (e) => {
    addModal.style.display = "none";
});

window.addEventListener('click', (event) => {
    if (event.target === addModal) {
        addModal.style.display = "none";
    }
});