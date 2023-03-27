const base_url_dev = "http://localhost:5145";
const base_url_prod = "";
const api_endpoints = {
    reserve: {
        base: "/reserve",
        id: "/reserve/{id}",
        new: "/reserve/new",
        update: "/reserve/update"
    },
    staff: {
        checkin: "/staff/checkin",
        checkout: "/staff/checkout",
        schedule: "/staff/schedule",
        salary: "/staff/salary",
        hours: "/staff/hours"
    },
    user: {
        new: "/user/create-user",
        login: "/user/login",
        logout: "/user/logout"
    }
}

