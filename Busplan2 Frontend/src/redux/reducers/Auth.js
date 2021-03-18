const INIT_STATE = {
    authUser: null,
    loadUser: false,
    send_forget_password_email: false,
}

export default (state = INIT_STATE, action) => {
    switch (action.type) {
        default:
            return state;
    }
}