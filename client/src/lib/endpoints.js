export const base_url_dev = "http://localhost:5145";
export const api_endpoints = {
    reserve: {
        base: "/reserve",
        new: "/reserve/new",
        update: "/reserve/update",
    },
    staff: {
        checkin: "/staff/checkin",
        checkout: "/staff/checkout",
        schedule: "/staff/schedule",
        salary: "/staff/salary",
        hours: "/staff/hours",
        active: "/staff/active",
    },
    user: {
        new: "/user/create-user",
        login: "/user/login",
        logout: "/user/logout",
    }
}
