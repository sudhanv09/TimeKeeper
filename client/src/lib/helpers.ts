import type { UserTimings, TimingDate } from './types';

function dayOfWeek(date: Date) {
	let weekday = date.getDay();
	weekday = ((weekday + 6) % 7) + 1;
	return weekday.toString();
}


export function genData(checkinData: UserTimings[]) {
	const d = new Date();
	const end = new Date(d.getFullYear(), d.getMonth(), d.getDate(), 0, 0, 0);
	let dt = new Date(d.setDate(end.getDate() - 180));
	let data: TimingDate[] = [];

	for (var i = 0; i < checkinData.length; i++) {
		const current = new Date(checkinData[i].checkIn).toISOString().substring(0, 10);
		const hours = checkinData[i].todaysHours.toPrecision(3);
		
		for (var j = 0; dt <= end; j++) {
			const iso = dt.toISOString().substring(0, 10);
			data.push({
				x: iso,
				y: dayOfWeek(dt),
				d: iso,
				v:
					current === iso
						? hours.toString()
						: '0'
			});

			dt = new Date(dt.setDate(dt.getDate() + 1));
		}
	}
	return data;
}
