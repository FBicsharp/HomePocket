export function initializeFileDropZone(dropZoneElement, inputFileContainer) {
    const inputFile = inputFileContainer.querySelector("input");    
    


    function onDragHover(e) {
        e.preventDefault();
        dropZoneElement.classList.add("hover");        
    }

    function onDragLeave(e) {
        e.preventDefault();
        dropZoneElement.classList.remove("hover");
    }

    function onDrop(e) {
        e.preventDefault();
        dropZoneElement.classList.remove("hover");
        inputFile.files = e.dataTransfer.files;
        const event = new Event('change', { bubbles: true });
        inputFile.dispatchEvent(event);        
    }
    function onClick(e) {        
        inputFile.click();        
        //e.preventDefault(); 
    }

    function onPaste(e) {

        inputFile.files = e.clipboardData.files;
        const event = new Event('change', { bubbles: true });
        inputFile.dispatchEvent(event);
    }
    dropZoneElement.addEventListener("dragenter", onDragHover);
    dropZoneElement.addEventListener("dragover", onDragHover);
    dropZoneElement.addEventListener("dragleave", onDragLeave);
    dropZoneElement.addEventListener("drop", onDrop);
    dropZoneElement.addEventListener("paste", onPaste);
    dropZoneElement.addEventListener("click", onClick);

    return {
        dispose: () => {
            dropZoneElement.removeEventListener("dragenter", onDragHover);
            dropZoneElement.removeEventListener("dragover", onDragHover);
            dropZoneElement.removeEventListener("dragleave", onDragLeave);
            dropZoneElement.removeEventListener("drop", onDrop);
            dropZoneElement.removeEventListener("paste", onPaste);
            dropZoneElement.removeEventListener("click", onClick);
        }

    }




}


