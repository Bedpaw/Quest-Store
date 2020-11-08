import {arrayUtils} from "@/utils/array-utils";

describe("UPDATE_ITEM", () => {
  it("update item replace item in array", () => {
    const array = [
      {id: 1, name: "Bob"},
      {id: 2, name: "Stefan"},
      {id: 3, name: "Helena"},
    ]
    const newItem = {id: 1, name: "NotBob"}

    arrayUtils.updateItem(array, newItem)

    expect(array).toEqual([
      {id: 1, name: "NotBob"},
      {id: 2, name: "Stefan"},
      {id: 3, name: "Helena"},
    ])
  })
})

describe("IS_EMPTY_ARRAY", () => {
  it("Returns true if array is empty", () => {
    const array = []

    const isEmpty = arrayUtils.isEmptyArray(array)

    expect(isEmpty).toEqual(true)
  })
})

describe("IS_EMPTY_ARRAY", () => {
  it("Returns false if array isnt empty", () => {
    const array = [null]

    const isEmpty = arrayUtils.isEmptyArray(array)

    expect(isEmpty).toEqual(false)
  })
})

describe("REMOVE_ITEM", () => {
  it("Remove item from array", () => {
    const array = [
      {id: 1, name: "Bob"},
      {id: 2, name: "Stefan"},
      {id: 3, name: "Helena"},
    ]
    const toRemove = {id: 3, name: "Helena"}

    arrayUtils.removeItem(array, toRemove)

    expect(array).toEqual(
      [
        {id: 1, name: "Bob"},
        {id: 2, name: "Stefan"},
      ]
    )
  })
})
