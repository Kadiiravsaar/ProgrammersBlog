function convertFirstLetterToUpperCase(text) { 
    // ilk harfi büyük harfe dönüitür
    return text.charAt(0).toUpperCase() + text.slice(1); // ilk harfi al.büyük harfe çevir + tüm cümleyi geri dön
}
function convertToShortDate(dateString) { // saati düzenlemek için createdDate and modifiedDate
    const shortDate = new Date(dateString).toLocaleDateString('en-US');
    return shortDate;
}