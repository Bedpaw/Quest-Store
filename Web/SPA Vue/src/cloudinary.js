import Vue from 'vue';
import Cloudinary, {
  CldImage,
  CldTransformation,
  CldContext
} from 'cloudinary-vue';

Vue.use(Cloudinary, {
  configuration: { cloudName: 'dohaaub56', responsive: true },
  components: {
    CldImage,
    CldTransformation,
    CldContext
  }
});
