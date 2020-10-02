import { ROUTES } from "@/utils/macros/routes.js";
import Home from "@/views/Home.vue";
import AdminBoard from "../views/AdminBoard";
import MentorBoard from "../views/MentorBoard";
import ClassDetails from "../components/ClassDetails";
import {authGuard} from "@/auth/authGuard";


export const routes = [
  {
    path: ROUTES.home.path,
    name: ROUTES.home.name,
    component: Home,
  },
  {
    path: ROUTES.admin.path,
    name: ROUTES.admin.name,
    component: AdminBoard,
    beforeEnter: authGuard
  },
  {
    path: ROUTES.mentor.path,
    name: ROUTES.mentor.name,
    component: MentorBoard
  },
  {
    path: ROUTES.classroom.path,
    name: ROUTES.classroom.name,
    component: ClassDetails
  },
  ]
