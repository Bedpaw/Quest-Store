export const nameRules = [
  v => !!v || 'Name is required',
  v => (v && v.length >= 2) || 'Name must have 2 or more letters',
]

export const surnameRules = [
  v => !!v || 'Surname is required',
  v => (v && v.length >= 2) || 'Surname must have 2 or more letters',
]

export const descriptionRules = [
  v => (v.length <= 100) || 'Description max length is 100 characters',
]

export const positive = [
  v => !!v || 'This field is required',
  v => (v && v >= 0) || 'This field must be 0 or greater',
]
export const emailRules = [
  v => !!v || 'E-mail is required',
  v => /.+@.+\..+/.test(v) || 'E-mail must be valid',
]
