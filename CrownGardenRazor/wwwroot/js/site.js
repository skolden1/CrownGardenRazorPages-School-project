let moreOptionsClicked = [];

const moreOptionsDiv = document.querySelectorAll(".m-container");
const commentsOptionsForms = document.querySelectorAll(".comments-options-form");

const onMoreOptionsClick = (moreOp) => {
    for (let i = 0; i < moreOptionsDiv.length; i++) {
        if (moreOp === moreOptionsDiv[i]) {
            if (moreOptionsClicked[i] === false) {
                changeDisplay(i, true);
                moreOptionsClicked[i] = true;
            }
            else {
                changeDisplay(i, false);
                moreOptionsClicked[i] = false;
            }
        }
    }
}

const changeDisplay = (moreOptionsDivIndex, showDisplay) => {
    let firstIndex = moreOptionsDivIndex * 2;
    let secondIndex = firstIndex + 1;

    if (showDisplay === true) {
        commentsOptionsForms[firstIndex].style.display = "block";
        commentsOptionsForms[secondIndex].style.display = "block";
    }
    else {
        commentsOptionsForms[firstIndex].style.display = "none";
        commentsOptionsForms[secondIndex].style.display = "none";
    }

}

moreOptionsDiv.forEach(moreOp => {
    moreOp.addEventListener("click", () => onMoreOptionsClick(moreOp));
    moreOptionsClicked.push(false);
})

