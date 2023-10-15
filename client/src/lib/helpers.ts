import type { UserTimings } from './types';

function dayOfWeek(date: Date) {
	let weekday = date.getDay();
	weekday = ((weekday + 6) % 7) + 1;
	return weekday.toString();
}

/* Create an array of dates for the last 30 days
	Check if the date matches checkin
	If true get the index and add the hours worked to data
*/



export function genData(checkinData: UserTimings[]) {
	const d = new Date();
	const end = new Date(d.getFullYear(), d.getMonth(), d.getDate(), 0, 0, 0);
	let dt = new Date(d.setDate(end.getDate() - 180));

	var data = [];
	while (dt <= end) {
		const iso = dt.toISOString().substr(0, 10);

		if (checkinData.find((x) => new Date(x.checkIn).toISOString().substr(0, 10) === iso)) {
			const index = checkinData.findIndex((x) => new Date(x.checkIn).toISOString().substr(0, 10) === iso);
			data.push({
				x: iso,
				y: dayOfWeek(dt),
				d: iso,
				v: checkinData[index].todaysHours
			});
		} else {			
			data.push({
				x: iso,
				y: dayOfWeek(dt),
				d: iso,
				v: '0'
			});
		}
		dt = new Date(dt.setDate(dt.getDate() + 1));
	}
	return data;
}
