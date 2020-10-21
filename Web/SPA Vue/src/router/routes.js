import { ROUTES } from "@/utils/macros/routes.js";
import Home from "@/views/Home.vue";
import AdminBoard from "../views/AdminBoard";
import MentorBoard from "../views/MentorBoard";
import ClassDetails from "../views/ClassDetails";
import {authGuard} from "@/auth/authGuard";
import Profile from "@/views/Profile";
import test from "@/views/test";
import Artifacts from "@/views/Artifacts";
import Quests from "@/views/Quests";
import MyClasses from "@/views/MyClasses";


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
    path: ROUTES.profile.path,
    name: ROUTES.profile.name,
    component: Profile,
    beforeEnter: authGuard
  },
  {
    path: ROUTES.classroom.path,
    name: ROUTES.classroom.name,
    component: ClassDetails
  },
  {
    path: ROUTES.artifacts.path,
    name: ROUTES.artifacts.name,
    component: Artifacts
  },
  {
    path: ROUTES.quests.path,
    name: ROUTES.quests.name,
    component: Quests
  },
  {
    path: ROUTES.myClasses.path,
    name: ROUTES.myClasses.name,
    component: MyClasses
  },
  {
    path: '/test',
    name: 'test',
    component: test
  }
  ]
