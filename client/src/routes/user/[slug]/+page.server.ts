import type { PageServerLoad } from './$types';
import type { UserTimings } from '$lib/types';

export const load = (async ({params}) => {  
    
	const timings: UserTimings[] = await fetch(`http://localhost:5145/staff/${params.slug}`).then(res =>
		res.json()
	);
	return {  userTime: timings};
	
}) satisfies PageServerLoad;
