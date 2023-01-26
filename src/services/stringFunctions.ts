export const idFromUrl = {
    getIdFromUrl
}
export const capitalize = {
    capitalizeFirstLetter
}

function getIdFromUrl(url: string) {
    let id = url.replace(/[\D]/g, '').slice(1) ;
    return Number(id);
}

function capitalizeFirstLetter(string: string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
  }