import { objectUtils } from '@/utils/object-utils';

export const dataTableMixin = {
  data: () => ({
    dialog: false,
    currentItem: {}
  }),
  methods: {
    editItem(item) {
      this.currentItem = { ...item };
      this.dialog = true;
    },
    clearEditedItem() {
      this.dialog = false;
      this.currentItem = {};
    }
  }
};

export const dataTableDialogMixin = {
  data() {
    return {
      editedItem: {},
      emptyItemTemplate: {}, // Define it in component
      formName: 'Item',
      valid: true
    };
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
  computed: {
    formTitle() {
      if (this.isEditMode()) return 'New ' + this.formName;
      return 'Edit ' + this.formName;
    }
  },
  watch: {
    dialog: function() {
      this.editedItem = { ...this.emptyItemTemplate, ...this.currentItem };
    }
  },
  methods: {
    save() {
      if (this.$refs.form.validate()) {
        this.$emit('itemChanged', this.editedItem);
      }
    },
    isEditMode() {
      return objectUtils.isEmptyObject(this.currentItem);
    },
    setImage(imageId) {
      this.editedItem.image = imageId;
    }
  }
};
