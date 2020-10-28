import Vue from 'vue';
import Cloudinary, { CldImage, CldTransformation, CldContext } from "cloudinary-vue";

Vue.use(Cloudinary, {
  configuration: { cloudName: 'dohaaub56' },
  components: {
    CldImage,
    CldTransformation,
    CldContext
  }
});
