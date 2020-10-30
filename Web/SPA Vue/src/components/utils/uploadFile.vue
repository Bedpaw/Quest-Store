<template>
  <div>
    <v-btn @click="openUploadModal">
      <slot>Upload Image</slot>
    </v-btn>
    <cld-context v-if="publicId !== ''" :cloudName="cloudName">
      <cld-image :publicId="publicId" auto crop="fit" />
    </cld-context>
    <p class="green--text mt-2">{{ uploadMessage }}</p>
  </div>
</template>

<script>
import {cloud_name, upload_preset} from "../../../cloudinary_config.json";

export default {
  name: 'uploadFile',
  data() {
    return {
      publicId: '',
      uploadMessage: '',
      cloudName: cloud_name
    }
  },
  methods: {
    openUploadModal() {
      window.cloudinary.openUploadWidget( { cloud_name, upload_preset },
          (error, result) => {
            if (!error && result && result.event === "success") {
              console.log('Done uploading..: ', result.info);
              this.uploadMessage = "Image uploaded"
              this.publicId = result.info.public_id
              this.$emit('image-uploaded', this.publicId)
            }
          }).open();
    }
  },
  beforeDestroy() {
    this.publicId = ''
    this.uploadMessage = ''
  }
}
</script>
