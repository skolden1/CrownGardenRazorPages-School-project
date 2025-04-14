let isMoreOptionDivClicked = false;

const moreOptionsDivs = document.querySelectorAll(".m-container");
const commentOptionsForm = document.querySelectorAll(".comments-options-form");

let latestIndex = -1;

const moreOptionsDivClicked = (i) => {
    if (latestIndex != -1) {

        let firstIndex = latestIndex * 2;
        let secondIndex = firstIndex + 1;

        commentOptionsForm[firstIndex].style.display = "none";
        commentOptionsForm[secondIndex].style.display = "none";

        firstIndex = i * 2;
        secondIndex = firstIndex + 1;

        commentOptionsForm[firstIndex].style.display = "block";
        commentOptionsForm[secondIndex].style.display = "block";

        latestIndex = i;
    }
    else {

        let firstIndex = i * 2;
        let secondIndex = firstIndex + 1;

        commentOptionsForm[firstIndex].style.display = "block";
        commentOptionsForm[secondIndex].style.display = "block";

        latestIndex = i;
    }
    
}

for (let i = 0; i < moreOptionsDivs.length; i++) {
    moreOptionsDivs[i].addEventListener('click', () => moreOptionsDivClicked(i));
}