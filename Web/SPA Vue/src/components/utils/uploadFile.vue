<template>
  <div>
    <v-btn @click="openUploadModal" class="primary">
      <slot>Upload Image</slot>
    </v-btn>
    <cld-context v-if="publicId !== '' && showPictureAfterUpload" :cloudName="cloudName" class="mt-4 align-center">
      <cld-image :publicId="publicId" auto height="150" width="150" crop="fill"/>
    </cld-context>
    <p class="green--text mt-2">{{ uploadMessage }}</p>
  </div>
</template>

<script>
import {cloud_name, upload_preset} from '../../../cloudinary_config.json';

export default {
  name: 'uploadFile',
  data() {
    return {
      publicId: '',
      uploadMessage: '',
      cloudName: cloud_name
    };
  },
  props: {
    showPictureAfterUpload: {
      default: false
    }
  },
  methods: {
    openUploadModal() {
      window.cloudinary
          .openUploadWidget({cloud_name, upload_preset}, (error, result) => {
            if (!error && result && result.event === 'success') {
              console.log('Done uploading..: ', result.info);
              this.uploadMessage = 'Image uploaded';
              this.publicId = result.info.public_id;
              this.$emit('image-uploaded', this.publicId);
            }
          })
          .open();
    }
  },
  beforeDestroy() {
    this.publicId = '';
    this.uploadMessage = '';
  }
};
</script>
