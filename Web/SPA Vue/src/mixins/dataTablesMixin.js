export const dataTableMixin = {
  data: () => ({
    dialog: false,
    currentItem: {}
  }),
  methods: {
    editItem (item) {
      this.currentItem = {...item}
      this.dialog = true
    },
    clearEditedItem() {
      this.dialog = false
      this.currentItem = {}
    },
  }
}

export const dataTableDialogMixin = {
  data() {
    return {
      editedItem: {}
    }
  },
  props: {
    dialog: {
      type: Boolean,
      default: false
    },
    currentItem: {
      type: Object
    }
  },
  watch:{
    dialog: function () {
      this.editedItem = {...this.currentItem}
    }
  },
  methods: {
    save() {this.$emit('itemChanged', this.editedItem)},
  }
}
