export const arrayUtils = {
  removeItem (array, toRemove) {
    const indexToRemove = array.indexOf(toRemove);
    return array.splice(indexToRemove, 1);
  },
  removeItemByIndex (array, indexToRemove) {
    return array.splice(indexToRemove, 1);
  },
  updateItem(array, newItem) {
    const itemToUpdate = array.find(item => item.id === newItem.id)
    const indexToReplace = array.indexOf(itemToUpdate);
    return array[indexToReplace] = newItem
  },
  isEmptyArray(array) {
    return (Array.isArray(array) && array.length === 0)
  }
};
